require "rubygems"
require "sequel"
require "logger"
require "uuidtools"
require "nokogiri"
require 'net/http'
require 'cgi'
require 'to_slug'

$lastfm_key = "b25b959554ed76058ac220b7b2e0a026" 
$lastfm_host = "ws.audioscrobbler.com"

def fetch_cover(artist, album)
	artist = CGI.escape(artist)
	album = CGI.escape(album)

	path = "/2.0/?method=album.getinfo&api_key=#{$lastfm_key}&artist=#{artist}&album=#{album}"
	begin
		data = Net::HTTP.get($lastfm_host, path)
		xml = Nokogiri::Slop(data)

		if xml.lfm.attributes['status'].content == 'ok' then
			puts "Found album cover for #{artist} - #{album}"
			album = xml.lfm.album
			cover = {
				:small => album.image("[size='small']").content,
				:medium => album.image("[size='medium']").content,
				:big => album.image("[size='large']").content
			}

			return cover
		end
	rescue
		return nil
	end
end

def open_xml
	f = File.open("db/chinook.xml")
	@doc = Nokogiri::XML(f)
end

def parse_key(key, &block)
	items = @doc.css(key)
	items.each do |item|
		def item.method_missing(meth, *args)
			found = self.at_css(meth.to_s)
			raise "Can't find #{meth}" if found.nil?
			found.content
		end
		yield(item)
	end
end
def load_albums
	parse_key("Album") do |item|
		@db[:Albums].insert(:Id => UUIDTools::UUID.timestamp_create.to_s,
				    :Name => item.Title,
				    :OriginalId => item.AlbumId.to_i,
				    :Slug => item.Title.to_slug,
				    :Artist_id => nil,
				    :Genre_id => nil)

	end
end
def load_artists
	parse_key("Artist") do |item|
		@db[:Artists].insert(:Id => UUIDTools::UUID.timestamp_create.to_s,
				     :Name => item.Name,
				     :OriginalId => item.ArtistId.to_i,
				     :Slug => item.Name.to_slug)
	end
end
def load_genres
	parse_key("Genre") do |item|
		@db[:Genres].insert(:Id => UUIDTools::UUID.timestamp_create.to_s,
				    :Name => item.Name,
				    :OriginalId => item.GenreId.to_i,
				    :Slug => item.Name.to_slug)
	end
end
def load_tracks
	parse_key("Track") do |item|
		@db[:Tracks].insert(:Id => UUIDTools::UUID.timestamp_create.to_s,
				    :Composer => item.Composer,
				    :Milliseconds => item.Milliseconds.to_i,
				    :Bytes => item.Bytes.to_i,
				    :UnitPrice => item.UnitPrice.to_f,
				    :OriginalId => item.TrackId.to_i)
	end
end

def load_customers
	parse_key("Customer") do |item|
		@db[:Customers].insert(:Id => UUIDTools::UUID.timestamp_create.to_s,
				       :OriginalId => item.CustomerId.to_i,
				       :FirstName => item.FirstName,
				       :LastName => item.LastName,
				       :Company => item.Company,
				       :Address => item.Address,
				       :City => item.City,
				       :State => item.State,
				       :Country => item.Country,
				       :PostalCode => item.PostalCode,
				       :Phone => item.Phone,
				       :Email => item.Email)
	end
end
def load_orders
	parse_key("Invoice") do |item|
		@db[:Orders].insert(:Id => UUIDTools::UUID.timestamp_create.to_s,
				    :OriginalId => item.InvoiceId.to_i,
				    :OrderDate  => item.InvoiceDate,
				    :Address => item.BillingAddress,
				    :City => item.BillingCity,
				    :State => item.BillingState,
				    :Country => item.BillingCountry,
				    :PostalCode => item.BillingPostalCode,
				    :Total => item.Total.to_f)
	end
end
def load_orders_details
	parse_key("InvoiceLine") do |item|
		@db[:OrderDetails].insert(:Id => UUIDTools::UUID.timestamp_create.to_s,
					  :OriginalId => item.InvoiceLineId.to_i,
					  :UnitPrice => item.UnitPrice.to_f,
					  :Quantity => item.Quantity.to_i)
	end
end

def associate	
	parse_key("Track") do |item|
		track = @db[:Tracks][:OriginalId => item.TrackId.to_i]
		album = @db[:Albums][:OriginalId => item.AlbumId.to_i]
		genre = @db[:Genres][:OriginalId => item.GenreId.to_i]
		puts "... adding #{track[:Name]} to #{album[:Name]} and setting to #{genre[:Name]}"

		@db[:Tracks].where(:Id => track[:Id]).update(:Album_id => album[:Id]);
		@db[:Albums].where(:Id => album[:Id]).update(:Genre_id => genre[:Id],:Price => 8.99);

	end
	parse_key("Album") do |item|

		album = @db[:Albums][:OriginalId => item.AlbumId.to_i]
		artist = @db[:Artists][:OriginalId => item.ArtistId.to_i]
		puts "... setting #{album[:Name]} artist to #{artist[:Name]}"

		cover = fetch_cover(artist[:Name], album[:Name])

		if cover.nil?
			@db[:Albums].where(:Id => album[:Id]).update(:Artist_id => artist[:Id]);
		else
			@db[:Albums].where(:Id => album[:Id]).update(:Artist_id => artist[:Id], :ArtSmall => cover[:small], :ArtMedium => cover[:medium], :ArtLarge => cover[:big]);
		end

	       
	end
	parse_key("Invoice") do |item|
		customer = @db[:Customers][:OriginalId => item.CustomerId.to_i]
		@db[:Orders].where(:OriginalId => item.InvoiceId.to_i).update(:Customer_id => customer[:Id])
	end
	parse_key("InvoiceLine") do |item|
		track = @db[:Tracks][:OriginalId => item.TrackId.to_i]
		invoice = @db[:Orders][:OriginalId => item.InvoiceId.to_i]
		@db[:OrderDetails].where(:OriginalId => item.InvoiceLineId.to_i).update(:Track_id => track[:Id], :Order_id => invoice[:Id])

	end


end

desc "Setup the chinook database and import the data from the xml file"
task :setupDb => :create_tables do
	puts "Opening xml file"
	open_xml
	load_customers
	load_orders
	load_orders_details

	puts "Import the genres"
	load_genres

	puts "Importing the artists"
	load_artists

	puts "Importing the albums"
	load_albums

	puts "Importing tracks"
	load_tracks

	associate

end

desc "Set up sequel"
task :set_up_sequel do
	puts "Create sqlite db."
	File.delete('db/chinook.db') if File.exists?('db/chinook.db') 
	@db = Sequel.sqlite 'db/chinook.db', :loggers => [Logger.new($stdout)]  
end

desc "Create the artist, album, and genre tables"
task :create_tables => :set_up_sequel do
	puts "Creating customers table"
	@db.create_table :Customers do 
		UUID :Id
		Integer :OriginalId
		String :FirstName
		String :LastName
		String :Company
		String :Email
		String :Address
		String :City
		String :State
		String :Country
		String :Phone
		String :Fax
		String :PostalCode
	end

	puts "Creating artist table"
	@db.create_table :Artists do
		UUID :Id
		Integer :OriginalId
		String :Name
		String :Slug
	end

	puts "Creating album table"
	@db.create_table :Albums do
		UUID :Id
		Integer :OriginalId
		String :Name
		String :Slug
		Float :Price
		String :ArtSmall
		String :ArtMedium
		String :ArtLarge
		UUID :Genre_id
		UUID :Artist_id
	end

	puts "Creating genre table"
	@db.create_table :Genres do
		UUID :Id
		Integer :OriginalId
		String :Name
		String :Slug
	end

	puts "Creating tracks table"
	@db.create_table :Tracks do 
		UUID :Id
		Integer :OriginalId
		String :Name
		String :Composer
		Integer :Milliseconds
		Integer :Bytes
		Float :UnitPrice
		UUID :Album_id
	end
	@db.create_table :Orders do
		UUID :Id
		Integer :OriginalId
		Date :OrderDate 
		String :Address
		String :City
		String :State
		String :Country
		String :Phone
		String :Fax
		String :PostalCode     
		Float :Total
		UUID :Customer_id
	end
	@db.create_table :OrderDetails do
		UUID :Id
		Integer :OriginalId
		UUID :Order_id
		UUID :Track_id
		Float :UnitPrice
		Integer :Quantity
	end

end

