namespace timesheet.common.Exceptions
{
    public class InvalidTimeEntryException : Exception
    {
        public InvalidTimeEntryException()
        {
        }

        public InvalidTimeEntryException(string message)
            : base(message)
        {
        }

        public InvalidTimeEntryException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
