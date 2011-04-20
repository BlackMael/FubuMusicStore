require "rubygems"
require "sequel"
require "logger"
require "uuidtools"
require "nokogiri"

def sluggify(title)
	title.downcase.gsub(" ","-").gsub("&","-n-").gsub("/","-").gsub(",","")	
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
				    :Slug => sluggify(item.Title),
				   :Artist_id => nil,
				   :Genre_id => nil)

	end
end
def load_artists
	parse_key("Artist") do |item|
		@db[:Artists].insert(:Id => UUIDTools::UUID.timestamp_create.to_s,
				    :Name => item.Name,
				    :OriginalId => item.ArtistId.to_i,
				    :Slug => sluggify(item.Name))
	end
end
def load_genres
	parse_key("Genre") do |item|
		@db[:Genres].insert(:Id => UUIDTools::UUID.timestamp_create.to_s,
				    :Name => item.Name,
				    :OriginalId => item.GenreId.to_i,
				    :Slug => sluggify(item.Name))
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
		@db[:Albums].where(:Id => album[:Id]).update(:Artist_id => artist[:Id]);
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

desc "Create some tables"
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

