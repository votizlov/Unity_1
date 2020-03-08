public class ConditionClick : Condition
{
    private bool _isEnabled = true;

    private void OnMouseDown()
    {
        if (_isEnabled)
            ExecuteAllActions(null);
    }

    public void SetEnabled(bool b)
    {
        _isEnabled = b;
    }
}