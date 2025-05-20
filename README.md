This is the backend API powering the frontend MFEs. It serves data related to investors and their financial commitments.
The API loads data from a data.csv file during startup via a seeding script.

Endpoint	Description
/api/investors	Get all investors
/api/investors/{id}/commitments	to Get commitments by investor
/api/investors/{id}/commitments?assetClass=Hedge Funds	to Filter commitments using asset classes

Swagger UI: http://localhost:5288/swagger/index.html


