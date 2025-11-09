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

Techniques for building RESTful APIs
ConcurrentDictionary
-	The AddOrUpdate  function
The ConcurrentDictionary is a dictionary that allows you to add, fetch and remove items in a thread-safe way. If you're going to be accessing a dictionary from multiple threads, then it should be your go-to class.
The vast majority of methods it exposes are thread safe, with the notable exception of one of the AddOrUpdate overloads:

public CompareData? Get(long id)
{
    Comparisons.TryGetValue(id, out var compareData);
    return compareData;
}

public void Put(long id, Side side, byte[] data)
{
    Comparisons.AddOrUpdate(id,
        _ => side == Side.Left
            ? new CompareData { Left = data }
            : new CompareData { Right = data },
        (_, existing) =>
        {
            if (side == Side.Left)
            {
                existing.Left = data;
            }
            else
            {
                existing.Right = data;
            }

            return existing;
        });
}






-	Enum 
public enum DiffResultType
{
    Equals,
    SizeDoNotMatch,
    ContentDoNotMatch
}

public enum Side
{
    Left,
    Right
}
Model resources, and collections
public class CompareData
{
    public byte[]? Left { get; set; }
    public byte[]? Right { get; set; }
}    
public class DiffData
{
    public byte[]? Data { get; set; }
}
public class Difference
{
    public long Offset { get; set; }
    public long Length { get; set; }
}
public class DiffResult
{
    public DiffResultType DiffResultType { get; set; }
    public List<Difference>? Diffs { get; set; }
}


Basic API controllers and routing
API controllers in ASP.NET Core inherit from the Controller class and use attributes to define routes. The common pattern is naming the controller <RouteName>Controller, and using the /[controller] attribute value, which automatically names the route based on the controller name:

# DiffApi
Diffing API Task
•	Provide 2 http endpoints (<host>/v1/diff/<ID>/left and <host>/v1/diff/<ID>/right) that accept 
JSON containing base64 encoded binary data on both endpoints. 
•	The provided data needs to be diff-ed and the results shall be available on a third endpoint 
(<host>/v1/diff/<ID>). The results shall provide the following info in JSON format: 

4.	If equal return that 
5.	oIf not of equal size just return that 
6.	If of same size provide insight in where the diff are, actual diffs are not needed. 
So mainly offsets + length in the data 

Testing it out
6.	Clone this repository
7.	Build the solution using Visual Studio, or on the command line with dotnet build.
8.	Run the project. The API will start up on http://localhost:5130, or http://localhost:7292 with dotnet run.
9.	Use DiffApi.http and test request form 1 to 4.
10.	Use an HTTP client like Postman or Fiddler to GET http://localhost:5130.

Techniques for building RESTful APIs
ConcurrentDictionary
-	The AddOrUpdate  function
The ConcurrentDictionary is a dictionary that allows you to add, fetch and remove items in a thread-safe way. If you're going to be accessing a dictionary from multiple threads, then it should be your go-to class.
The vast majority of methods it exposes are thread safe, with the notable exception of one of the AddOrUpdate overloads:

public CompareData? Get(long id)
{
    Comparisons.TryGetValue(id, out var compareData);
    return compareData;
}

public void Put(long id, Side side, byte[] data)
{
    Comparisons.AddOrUpdate(id,
        _ => side == Side.Left
            ? new CompareData { Left = data }
            : new CompareData { Right = data },
        (_, existing) =>
        {
            if (side == Side.Left)
            {
                existing.Left = data;
            }
            else
            {
                existing.Right = data;
            }

            return existing;
        });
}






-	Enum 
public enum DiffResultType
{
    Equals,
    SizeDoNotMatch,
    ContentDoNotMatch
}

public enum Side
{
    Left,
    Right
}
Model resources, and collections
# DiffApi
Diffing API Task
•	Provide 2 http endpoints (<host>/v1/diff/<ID>/left and <host>/v1/diff/<ID>/right) that accept 
JSON containing base64 encoded binary data on both endpoints. 
•	The provided data needs to be diff-ed and the results shall be available on a third endpoint 
(<host>/v1/diff/<ID>). The results shall provide the following info in JSON format: 

7.	If equal return that 
8.	oIf not of equal size just return that 
9.	If of same size provide insight in where the diff are, actual diffs are not needed. 
So mainly offsets + length in the data 

Testing it out
11.	Clone this repository
12.	Build the solution using Visual Studio, or on the command line with dotnet build.
13.	Run the project. The API will start up on http://localhost:5130, or http://localhost:7292 with dotnet run.
14.	Use DiffApi.http and test request form 1 to 4.
15.	Use an HTTP client like Postman or Fiddler to GET http://localhost:5130.

Techniques for building RESTful APIs
ConcurrentDictionary
-	The AddOrUpdate  function
The ConcurrentDictionary is a dictionary that allows you to add, fetch and remove items in a thread-safe way. If you're going to be accessing a dictionary from multiple threads, then it should be your go-to class.
The vast majority of methods it exposes are thread safe, with the notable exception of one of the AddOrUpdate overloads:

public CompareData? Get(long id)
{
    Comparisons.TryGetValue(id, out var compareData);
    return compareData;
}

public void Put(long id, Side side, byte[] data)
{
    Comparisons.AddOrUpdate(id,
        _ => side == Side.Left
            ? new CompareData { Left = data }
            : new CompareData { Right = data },
        (_, existing) =>
        {
            if (side == Side.Left)
            {
                existing.Left = data;
            }
            else
            {
                existing.Right = data;
            }

            return existing;
        });
}






-	Enum 
public enum DiffResultType
{
    Equals,
    SizeDoNotMatch,
    ContentDoNotMatch
}

public enum Side
{
    Left,
    Right
}
Model resources, and collections
# DiffApi
Diffing API Task
•	Provide 2 http endpoints (<host>/v1/diff/<ID>/left and <host>/v1/diff/<ID>/right) that accept 
JSON containing base64 encoded binary data on both endpoints. 
•	The provided data needs to be diff-ed and the results shall be available on a third endpoint 
(<host>/v1/diff/<ID>). The results shall provide the following info in JSON format: 

10.	If equal return that 
11.	oIf not of equal size just return that 
12.	If of same size provide insight in where the diff are, actual diffs are not needed. 
So mainly offsets + length in the data 

Testing it out
16.	Clone this repository
17.	Build the solution using Visual Studio, or on the command line with dotnet build.
18.	Run the project. The API will start up on http://localhost:5130, or http://localhost:7292 with dotnet run.
19.	Use DiffApi.http and test request form 1 to 4.
20.	Use an HTTP client like Postman or Fiddler to GET http://localhost:5130.

Techniques for building RESTful APIs
ConcurrentDictionary
-	The AddOrUpdate  function
The ConcurrentDictionary is a dictionary that allows you to add, fetch and remove items in a thread-safe way. If you're going to be accessing a dictionary from multiple threads, then it should be your go-to class.
The vast majority of methods it exposes are thread safe, with the notable exception of one of the AddOrUpdate overloads:

public CompareData? Get(long id)
{
    Comparisons.TryGetValue(id, out var compareData);
    return compareData;
}

public void Put(long id, Side side, byte[] data)
{
    Comparisons.AddOrUpdate(id,
        _ => side == Side.Left
            ? new CompareData { Left = data }
            : new CompareData { Right = data },
        (_, existing) =>
        {
            if (side == Side.Left)
            {
                existing.Left = data;
            }
            else
            {
                existing.Right = data;
            }

            return existing;
        });
}






-	Enum 
# DiffApi
Diffing API Task
•	Provide 2 http endpoints (<host>/v1/diff/<ID>/left and <host>/v1/diff/<ID>/right) that accept 
JSON containing base64 encoded binary data on both endpoints. 
•	The provided data needs to be diff-ed and the results shall be available on a third endpoint 
(<host>/v1/diff/<ID>). The results shall provide the following info in JSON format: 

13.	If equal return that 
14.	oIf not of equal size just return that 
15.	If of same size provide insight in where the diff are, actual diffs are not needed. 
So mainly offsets + length in the data 

Testing it out
21.	Clone this repository
22.	Build the solution using Visual Studio, or on the command line with dotnet build.
23.	Run the project. The API will start up on http://localhost:5130, or http://localhost:7292 with dotnet run.
24.	Use DiffApi.http and test request form 1 to 4.
25.	Use an HTTP client like Postman or Fiddler to GET http://localhost:5130.

Techniques for building RESTful APIs
ConcurrentDictionary
-	The AddOrUpdate  function
The ConcurrentDictionary is a dictionary that allows you to add, fetch and remove items in a thread-safe way. If you're going to be accessing a dictionary from multiple threads, then it should be your go-to class.
The vast majority of methods it exposes are thread safe, with the notable exception of one of the AddOrUpdate overloads:

# DiffApi
Diffing API Task
•	Provide 2 http endpoints (<host>/v1/diff/<ID>/left and <host>/v1/diff/<ID>/right) that accept 
JSON containing base64 encoded binary data on both endpoints. 
•	The provided data needs to be diff-ed and the results shall be available on a third endpoint 
(<host>/v1/diff/<ID>). The results shall provide the following info in JSON format: 

16.	If equal return that 
17.	oIf not of equal size just return that 
18.	If of same size provide insight in where the diff are, actual diffs are not needed. 
So mainly offsets + length in the data 

Testing it out
26.	Clone this repository
27.	Build the solution using Visual Studio, or on the command line with dotnet build.
28.	Run the project. The API will start up on http://localhost:5130, or http://localhost:7292 with dotnet run.
29.	Use DiffApi.http and test request form 1 to 4.
30.	Use an HTTP client like Postman or Fiddler to GET http://localhost:5130.

Techniques for building RESTful APIs
ConcurrentDictionary
-	The AddOrUpdate  function
The ConcurrentDictionary is a dictionary that allows you to add, fetch and remove items in a thread-safe way. If you're going to be accessing a dictionary from multiple threads, then it should be your go-to class.
The vast majority of methods it exposes are thread safe, with the notable exception of one of the AddOrUpdate overloads:

public CompareData? Get(long id)
{
    Comparisons.TryGetValue(id, out var compareData);
    return compareData;
}

public void Put(long id, Side side, byte[] data)
{
    Comparisons.AddOrUpdate(id,
        _ => side == Side.Left
            ? new CompareData { Left = data }
            : new CompareData { Right = data },
        (_, existing) =>
        {
            if (side == Side.Left)
            {
                existing.Left = data;
            }
            else
            {
                existing.Right = data;
            }

            return existing;
        });
}






-	Enum 
public enum DiffResultType
{
    Equals,
    SizeDoNotMatch,
    ContentDoNotMatch
}

public enum Side
{
    Left,
    Right
}
Model resources, and collections
public class CompareData
{
    public byte[]? Left { get; set; }
    public byte[]? Right { get; set; }
}    
public class DiffData
{
    public byte[]? Data { get; set; }
}
public class Difference
{
    public long Offset { get; set; }
    public long Length { get; set; }
}
public class DiffResult
{
    public DiffResultType DiffResultType { get; set; }
    public List<Difference>? Diffs { get; set; }
}


Basic API controllers and routing
API controllers in ASP.NET Core inherit from the Controller class and use attributes to define routes. The common pattern is naming the controller <RouteName>Controller, and using the /[controller] attribute value, which automatically names the route based on the controller name:
// Handles all routes under /comments
[HttpGet]
[Route("{id:long}")]
public ActionResult Get(long id)
{
    var compareData = _diffRepository.Get(id);

    if(compareData is null || compareData.Left is null || compareData.Right is null)
    {
        return NotFound();
    }

    if (compareData.Left.SequenceEqual(compareData.Right))
    {
        return Ok(new DiffResult()
        {
            DiffResultType = DiffResultType.Equals
        });
    }

    if (compareData.Left?.Length != compareData.Right?.Length)
    {
        return Ok(new DiffResult()
        {
            DiffResultType = DiffResultType.SizeDoNotMatch
        });
    }

    return Ok(new DiffResult()
    {
        DiffResultType = DiffResultType.ContentDoNotMatch,
        Diffs = _diffService.GetDifferences(compareData.Left!, compareData.Right!)
    });
}

[HttpPut]
[Route("{id:long}/{side}")]
public ActionResult Put(long id, Side side, [FromBody] DiffData data)
{
    if (data.Data is null)
    {
        _logger.LogWarning("Data is null");
        return BadRequest();
    }

    _diffRepository.Put(id, side, data.Data);
    _logger.LogInformation("Data stored for id {Id} on side {Side}", id, side);

    return Created();
}

Enum 
public enum DiffResultType
{
    Equals,
    SizeDoNotMatch,
    ContentDoNotMatch
}

public enum Side
{
    Left,
    Right
}
Model resources, and collections
public class CompareData
{
    public byte[]? Left { get; set; }
    public byte[]? Right { get; set; }
}    
public class DiffData
{
    public byte[]? Data { get; set; }
}
public class Difference
{
    public long Offset { get; set; }
    public long Length { get; set; }
}
public class DiffResult
{
    public DiffResultType DiffResultType { get; set; }
    public List<Difference>? Diffs { get; set; }
}


Basic API controllers and routing
API controllers in ASP.NET Core inherit from the Controller class and use attributes to define routes. The common pattern is naming the controller <RouteName>Controller, and using the /[controller] attribute value, which automatically names the route based on the controller name:
// Handles all routes under /comments
[HttpGet]
[Route("{id:long}")]
public ActionResult Get(long id)
{
    var compareData = _diffRepository.Get(id);

    if(compareData is null || compareData.Left is null || compareData.Right is null)
    {
        return NotFound();
    }

    if (compareData.Left.SequenceEqual(compareData.Right))
    {
        return Ok(new DiffResult()
        {
            DiffResultType = DiffResultType.Equals
        });
    }

    if (compareData.Left?.Length != compareData.Right?.Length)
    {
        return Ok(new DiffResult()
        {
            DiffResultType = DiffResultType.SizeDoNotMatch
        });
    }

    return Ok(new DiffResult()
    {
        DiffResultType = DiffResultType.ContentDoNotMatch,
        Diffs = _diffService.GetDifferences(compareData.Left!, compareData.Right!)
    });
}

[HttpPut]
[Route("{id:long}/{side}")]
public ActionResult Put(long id, Side side, [FromBody] DiffData data)
{
    if (data.Data is null)
    {
        _logger.LogWarning("Data is null");
        return BadRequest();
    }

    _diffRepository.Put(id, side, data.Data);
    _logger.LogInformation("Data stored for id {Id} on side {Side}", id, side);

    return Created();
}
Model resources, and collections
public class CompareData
{
    public byte[]? Left { get; set; }
    public byte[]? Right { get; set; }
}    
public class DiffData
{
    public byte[]? Data { get; set; }
}
public class Difference
{
    public long Offset { get; set; }
    public long Length { get; set; }
}
public class DiffResult
{
    public DiffResultType DiffResultType { get; set; }
    public List<Difference>? Diffs { get; set; }
}


Basic API controllers and routing
API controllers in ASP.NET Core inherit from the Controller class and use attributes to define routes. The common pattern is naming the controller <RouteName>Controller, and using the /[controller] attribute value, which automatically names the route based on the controller name:
// Handles all routes under /comments
[HttpGet]
[Route("{id:long}")]
public ActionResult Get(long id)
{
    var compareData = _diffRepository.Get(id);

    if(compareData is null || compareData.Left is null || compareData.Right is null)
    {
        return NotFound();
    }

    if (compareData.Left.SequenceEqual(compareData.Right))
    {
        return Ok(new DiffResult()
        {
            DiffResultType = DiffResultType.Equals
        });
    }

    if (compareData.Left?.Length != compareData.Right?.Length)
    {
        return Ok(new DiffResult()
        {
            DiffResultType = DiffResultType.SizeDoNotMatch
        });
    }

    return Ok(new DiffResult()
    {
        DiffResultType = DiffResultType.ContentDoNotMatch,
        Diffs = _diffService.GetDifferences(compareData.Left!, compareData.Right!)
    });
}

[HttpPut]
[Route("{id:long}/{side}")]
public ActionResult Put(long id, Side side, [FromBody] DiffData data)
{
    if (data.Data is null)
    {
        _logger.LogWarning("Data is null");
        return BadRequest();
    }

    _diffRepository.Put(id, side, data.Data);
    _logger.LogInformation("Data stored for id {Id} on side {Side}", id, side);

    return Created();
}


Basic API controllers and routing
API controllers in ASP.NET Core inherit from the Controller class and use attributes to define routes. The common pattern is naming the controller <RouteName>Controller, and using the /[controller] attribute value, which automatically names the route based on the controller name:
// Handles all routes under /comments
[HttpGet]
[Route("{id:long}")]
public ActionResult Get(long id)
{
    var compareData = _diffRepository.Get(id);

    if(compareData is null || compareData.Left is null || compareData.Right is null)
    {
        return NotFound();
    }

    if (compareData.Left.SequenceEqual(compareData.Right))
    {
        return Ok(new DiffResult()
        {
            DiffResultType = DiffResultType.Equals
        });
    }

    if (compareData.Left?.Length != compareData.Right?.Length)
    {
        return Ok(new DiffResult()
        {
            DiffResultType = DiffResultType.SizeDoNotMatch
        });
    }

    return Ok(new DiffResult()
    {
        DiffResultType = DiffResultType.ContentDoNotMatch,
        Diffs = _diffService.GetDifferences(compareData.Left!, compareData.Right!)
    });
}

[HttpPut]
[Route("{id:long}/{side}")]
public ActionResult Put(long id, Side side, [FromBody] DiffData data)
{
    if (data.Data is null)
    {
        _logger.LogWarning("Data is null");
        return BadRequest();
    }

    _diffRepository.Put(id, side, data.Data);
    _logger.LogInformation("Data stored for id {Id} on side {Side}", id, side);

    return Created();
}


Basic API controllers and routing
API controllers in ASP.NET Core inherit from the Controller class and use attributes to define routes. The common pattern is naming the controller <RouteName>Controller, and using the /[controller] attribute value, which automatically names the route based on the controller name:
// Handles all routes under /comments
[HttpGet]
[Route("{id:long}")]
public ActionResult Get(long id)
{
    var compareData = _diffRepository.Get(id);

    if(compareData is null || compareData.Left is null || compareData.Right is null)
    {
        return NotFound();
    }

    if (compareData.Left.SequenceEqual(compareData.Right))
    {
        return Ok(new DiffResult()
        {
            DiffResultType = DiffResultType.Equals
        });
    }

    if (compareData.Left?.Length != compareData.Right?.Length)
    {
        return Ok(new DiffResult()
        {
            DiffResultType = DiffResultType.SizeDoNotMatch
        });
    }

    return Ok(new DiffResult()
    {
        DiffResultType = DiffResultType.ContentDoNotMatch,
        Diffs = _diffService.GetDifferences(compareData.Left!, compareData.Right!)
    });
}

[HttpPut]
[Route("{id:long}/{side}")]
public ActionResult Put(long id, Side side, [FromBody] DiffData data)
{
    if (data.Data is null)
    {
        _logger.LogWarning("Data is null");
        return BadRequest();
    }

    _diffRepository.Put(id, side, data.Data);
    _logger.LogInformation("Data stored for id {Id} on side {Side}", id, side);

    return Created();
}

