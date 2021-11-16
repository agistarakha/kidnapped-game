public class Warp : RoomAccessPoint
{
    public override void PlayerEnterFeedback()
    {
        base.PlayerEnterFeedback();
        LoadConnectedScene();
    }
}
