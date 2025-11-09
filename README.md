# DiffApi
Diffing API Task
•	Provide 2 http endpoints (<host>/v1/diff/<ID>/left and <host>/v1/diff/<ID>/right) that accept 
JSON containing base64 encoded binary data on both endpoints. 
•	The provided data needs to be diff-ed and the results shall be available on a third endpoint 
(<host>/v1/diff/<ID>). The results shall provide the following info in JSON format: 

1.	If equal return that 
2.	oIf not of equal size just return that 
3.	If of same size provide insight in where the diff are, actual diffs are not needed. 
So mainly offsets + length in the data 

Testing it out
1.	Clone this repository
2.	Build the solution using Visual Studio, or on the command line with dotnet build.
3.	Run the project. The API will start up on http://localhost:5130, or http://localhost:7292 with dotnet run.
4.	Use DiffApi.http and test request form 1 to 4.
5.	Use an HTTP client like Postman or Fiddler to GET http://localhost:5130.
