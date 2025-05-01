// To Store data for the task controller that doesn't need to be in the database. Usually used for simple data sets, nothing too complex, otherwise use the model.
public readonly struct TaskSummary
{
    public int Total { get; }
    public int Completed { get; }

    public TaskSummary(int total, int completed)
    {
        Total = total;
        Completed = completed;
    }

    public int Remaining => Total - Completed;
}
