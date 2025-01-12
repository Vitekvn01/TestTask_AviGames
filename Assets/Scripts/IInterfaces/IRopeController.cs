using System;

public interface IRopeController
{
    public event Action OnCheckIntersectionEvent;

    public void AddRope(Rope rope);

    public void CheckRopeIntersection();
}
