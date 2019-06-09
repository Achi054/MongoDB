# MongoDB
Working with NoSql database MongoDB.

MongoDB stores data in flexible, JSON-like documents, meaning fields can vary from document to document and data structure can be changed over time.

The document model maps to the objects in your application code, making data easy to work with.

Ad hoc queries, indexing, and real time aggregation provide powerful ways to access and analyze your data.

MongoDB is a distributed database at its core, so high availability, horizontal scaling, and geographic distribution are built in and easy to use.

## Setting up MongoDB
- Downloading msi <br/>
    Get the MongoDB installer based on your system specification from 
    ```
    https://www.mongodb.com/download-center/community.
    ```
    Setup environment to have Mongodb path,<br/>
    In the search, type `environment`, in the `PATH` variable add mongodb exe path.<br/><br/>
    Once installation is complete, run `mongo --version` to verify.

- Setting MongoDB <br/>
    Create 2 folders within MongoDB path, `data` and `log`.<br/>
    Run run the below script
    ```
    mongod --directoryperdb --dbpath <path to data folder> --logpath <path to log folder> --logappend --rest --install
    ```
    this would create a MongoDB service. <br/>
    Run 
    ```
    netstart MongoDB
    ```

- Setting up MongoDB from Cloud Atlas <br/>
    In the Command prompt run
    ```
    mongo --host <connection url> 
    ```

## Working with MongoDB
- Check default DB
    ```
    show dbs
    ```
- Create and use a database
    ```
    use test
    ```
    Creates db `test` if not exists.
- Create new user
    ```
    db.createUser({
        user: "<user-name>",
        pwd: "<password>",
        roles: ['readWrite', 'dbAdmin']
    });
    ```
-  Create collections/Tables
    ```
    db.createCollection('customers')
    show collections
    ```
- Insert values to the Customers collection
    ```
    db.Customers.insertOne({ 
        first_name: "Bob",
        last_name: "Mitch"
    });

    db.Customers.insertMany([{ 
        first_name: "Dan",
        last_name: "Mitch"
    },
    { 
        first_name: "Stan",
        last_name: "Mitch"
    }]);
    ```
    To get the collection
    ```
    db.Customers.find();
    ```
- Find a specific record in a collection
    ```
    Find specific
    db.inventory.find( { first_name: "Dan" } )

    Find matching $in condition
    db.Customers.find({ first_name: { $in: ["Dan", "Stan"] } })

    Find matching last_name and first_name
    db.Customers.find({ last_name: "Mitch", first_name: "Dan" })

    Find with $or condition
    db.Customers.find({ $or: [{ first_name: "Dan" }, { first_name: "Stan" }]})

    Find with columns to be shown
    db.Customers.find({ first_name: "Dan"}, { first_name: 1, last_name: 1})
    ```
- Update values in a collection
    ```
    Update one item
    db.inventory.updateOne(
   { item: "paper" },
   {
     $set: { "size.uom": "cm", status: "P" },
     $currentDate: { lastModified: true }
   })

   Update collection matching condition
   db.inventory.updateMany(
   { "qty": { $lt: 50 } },
   {
     $set: { "size.uom": "in", status: "P" },
     $currentDate: { lastModified: true }
   })

   Replace the record in the collection matching condition
   db.inventory.replaceOne(
   { item: "paper" },
   { item: "paper", instock: [ { warehouse: "A", qty: 60 }, { warehouse: "B", qty: 40 } ] })
    ```
- Delete values form collection
    ```
    Delete all documents from the collection
    db.inventory.deleteMany({})

    Delete all that match a condition
    db.inventory.deleteMany({ first_name : "Sujith" })

    Delete one document matching condition
    db.inventory.deleteOne( { first_name: "Sujith" } )

    Delete based on sort order of last_name
    db.scores.findOneAndDelete(
   { first_name : "Sujith" },
   { sort : { "last_name" : 1 } })
    ```
 - Bulk write
    ```
    db.characters.bulkWrite(
      [
         { insertOne :
            {
               "document" :
               {
                  "_id" : 4, "char" : "Dithras", "class" : "barbarian", "lvl" : 4
               }
            }
         },
         { insertOne :
            {
               "document" :
               {
                  "_id" : 5, "char" : "Taeln", "class" : "fighter", "lvl" : 3
               }
            }
         },
         { updateOne :
            {
               "filter" : { "char" : "Eldon" },
               "update" : { $set : { "status" : "Critical Injury" } }
            }
         },
         { deleteOne :
            { "filter" : { "char" : "Brisbane"} }
         },
         { replaceOne :
            {
               "filter" : { "char" : "Meldane" },
               "replacement" : { "char" : "Tanys", "class" : "oracle", "lvl" : 4 }
            }
         }
      ]
   );
    ```





