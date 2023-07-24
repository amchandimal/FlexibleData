n # FlexibleData
FlexibleDataApplication

## Solution

1. Created an endpoint at POST /flexibledata/create that accepts a payload of a JSON object with the following structure:

        {
            "Data": "dictionary of key-value pairs"
        }

- The endpoint returns the created data object with a 200 OK response, if the data was successfully stored in the database.

2. An endpoint GET /flexibledata/get/{?id} created to retrieve one or more data objects from the database. 

    - The endpoint returns the data object with a 200 OK response, if the data was successfully retrieved from the database.
    - If the data object is not found, the endpoint returns a 404 Not Found response.
    - If the ID is not provided, the endpoint returns all data objects in the database with a 200 OK response.
  
3. The post-processing system will process the data objects in the database. The system is triggered by a successful data object creation.
    - The system should count the number of flexible data objects that has a value for a given key.

4. An endpoint  GET /flexibledata/count/{?key} created to retrieve the count of a given key.

    - The endpoint returns the count of the given key with a 200 OK response,with count of Unique values, if the count was successfully retrieved from the database.
    - If no data is found, the endpoint returns a 404 Not Found response.
    - If the key is not provided, the endpoint should return all data in the table.

## Running Application

You need following Applications & Tools to be installed in your PC

- [Docker](https://www.postman.com/)
- [Docker Compose](https://docs.docker.com/compose)
- [PostMan](https://www.postman.com/)

Once You Installed Docker in Your PC you can use following command from the directory "FlexibleDataApplication" to build the docker image for yourself

    docker build -t [imagename] .

Else you can use following command to run the application with Docker Compose 

    docker-compose up

If you build the image on your own, change the following segment in the docker-compose.yml and run above command

    flexibledata-core:
        image: [imagename]

## Testing Application

1. Import "FlexibleData.postman_collection.json" to postman.
2. Right Click the Collection & Click Run Collection
3. Make sure the Run Order is As below


Click Run Button.

