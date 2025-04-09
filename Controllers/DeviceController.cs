using System.Collections.Concurrent;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

// This class is a bit convoluted due to the absence of the data layer part. 
// Ideally, it would not split data and leave them encapsulated.
[ApiController]
[Route("api")]
public class DeviceController : ControllerBase
{
    private static ConcurrentDictionary<string, Stack<Measurement>> _records = new ConcurrentDictionary<string, Stack<Measurement>>();

    [HttpPost("add-record")]
    public async Task<ActionResult> AddRecord([FromBody] Device device)
    {
        if (!device.Measurements.Data.IsDataValid()) return BadRequest();

        //In best case scenario adding and communication should be also decoupled
        _records.AddOrUpdate(
            device.Name,
            _ => new Stack<Measurement>([device.Measurements]),
            (_, stack) =>
                {
                    stack.Push(device.Measurements);
                    return stack;
                });
        return Ok();
    }

    [HttpGet("devices")]
    public async Task<ActionResult<List<string>>> GetDevices()
    {
        return Ok(JsonSerializer.Serialize(_records.Keys));
    }

    public async Task<List<Measurement>> GetMeasurements(string deviceName)
    {
        if (!_records.TryGetValue(deviceName, out Stack<Measurement> measurements))
        {
            return new Stack<Measurement>().ToList();
        }
        return measurements.ToList();
    }

    [HttpGet("devices-count")]
    public async Task<ActionResult<int>> GetMeasurementsCount(string deviceName)
    {
        if (!_records.TryGetValue(deviceName, out Stack<Measurement> measurements))
        {
            return Ok(0);
        }
        return Ok(measurements.Count);
    }
}