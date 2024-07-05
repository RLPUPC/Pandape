namespace Pandape.Application;

public class MockClockManager: IClockManager
{
    private DateTime _currentUtc;

    public DateTime GetCurrentUtc() 
    { 
        return _currentUtc; 
    }

    public void SetCurrentUtc(DateTime utc) 
    {
        _currentUtc = utc;
    }
}
