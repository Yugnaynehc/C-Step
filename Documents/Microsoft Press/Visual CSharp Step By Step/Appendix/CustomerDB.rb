class Customer
  attr_reader :custID
  attr_accessor :custName
  attr_accessor :custTelephone
  
  def initialize(id, name, telephone)
    @custID = id
    @custName = name
    @custTelephone = telephone
  end
  
  def to_s
    return "ID: #{custID}\tName: #{custName}\tTelephone: #{custTelephone}"
  end
end

class CustomerDB  
  attr_reader  :customerDatabase
  
  def initialize
    @customerDatabase ={}
  end
  
  def storeCustomer(customer)
   @customerDatabase[customer.custID] = customer
 end
 
  def getCustomer(id)
    return @customerDatabase[id]
  end
  
  def to_s
    list = "Customers\n"
    @customerDatabase.each {
      |key, value|
      list = list + "#{value}" + "\n"
    }
    return list
  end
end

def GetNewCustomer(id, name, telephone)
  return Customer.new(id, name, telephone)
end

def GetCustomerDB
  return CustomerDB.new
end