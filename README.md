# REST API
## RESTFUL Movies API

Project is use of REST API architecture. Topic of the API is movies database.
Entities included in database are: movies, actors/directors, film production company, countries.
To manage entities in database Entity Framework Core was used. Project is configured to use PostgreSQL RDBM on localhost.

## Implemented functionalities
### Movie entity:
* GET - show all movies,
* GET/id - show movie by id,
* GET/title movie by title,
* POST - add new movie,
* PUT/id - edit movie,
* DELETE/id - remove movie by id.

### Person entity:
* GET - show all actors/directors,
* GET/id - show actor/director by id

### Producer entiry:
* GET - show all producers,
* GET/id - show producer by id,
* POST - add new producer,
* PUT/id - edit producer,
* DELETE/id - remove producer by id.

## Missing functionalities
Extraction of EF Core queries to DAO/Repository pattern.
