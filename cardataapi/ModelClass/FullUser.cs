namespace cardataapi;
public class FullUser
{
    public int TestPersonNumber { get; set; }
    public int? Age { get; set; }
    public string? Gender { get; set; }

    // Pulse
    public int PulseMeasurements { get; set; }
    public double? AveragePulse { get; set; }
    public int? MinPulse { get; set; }
    public int? MaxPulse { get; set; }

    // Bike
    public int BikeMeasurements { get; set; }
    public double? AverageSpeed { get; set; }
    public double? MaxSpeed { get; set; }
    public double? AverageDistanceCurbSide { get; set; }
    public double? MinDistanceCurbSide { get; set; }
    public double? AverageHandleRotationY { get; set; }

    // Head
    public int HeadTransformMeasurements { get; set; }

    // Left brake
    public int LeftBrakeMeasurements { get; set; }
    public int LeftBrakeEvents { get; set; }

    // Right brake
    public int RightBrakeMeasurements { get; set; }
    public int RightBrakeEvents { get; set; }

    // Scenarios
    public int ScenarioCount { get; set; }

    public FullUser(
        int testPersonNumber,
        int? age,
        string? gender,
        int pulseMeasurements,
        double? averagePulse,
        int? minPulse,
        int? maxPulse,
        int bikeMeasurements,
        double? averageSpeed,
        double? maxSpeed,
        double? averageDistanceCurbSide,
        double? minDistanceCurbSide,
        double? averageHandleRotationY,
        int headTransformMeasurements,
        int leftBrakeMeasurements,
        int leftBrakeEvents,
        int rightBrakeMeasurements,
        int rightBrakeEvents,
        int scenarioCount)
    {
        TestPersonNumber = testPersonNumber;
        Age = age;
        Gender = gender;

        PulseMeasurements = pulseMeasurements;
        AveragePulse = averagePulse;
        MinPulse = minPulse;
        MaxPulse = maxPulse;

        BikeMeasurements = bikeMeasurements;
        AverageSpeed = averageSpeed;
        MaxSpeed = maxSpeed;
        AverageDistanceCurbSide = averageDistanceCurbSide;
        MinDistanceCurbSide = minDistanceCurbSide;
        AverageHandleRotationY = averageHandleRotationY;

        HeadTransformMeasurements = headTransformMeasurements;

        LeftBrakeMeasurements = leftBrakeMeasurements;
        LeftBrakeEvents = leftBrakeEvents;

        RightBrakeMeasurements = rightBrakeMeasurements;
        RightBrakeEvents = rightBrakeEvents;

        ScenarioCount = scenarioCount;
    }
}
