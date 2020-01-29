# TvMaze Scraper and API 

An example api scraper and an api to serve its results

## Notes

### The implementation includes an in-memory db context, which ensures some basic data is inserted into shows and cast members tables.
### The scraper project can be compiled as an executable and scheduled as a windows task (other options are available)
### The scraper itself does not save anything to db, but the implementation should be clear
### For an example response from the api, run the web api project and call in browser /api/shows?pageNumber=1&pageSize=1 (which will return the first result from the first page)

## Cheers! and thanks for the opportunity