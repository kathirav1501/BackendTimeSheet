namespace BackendEss.Model
{
    public abstract class BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        // Constructor to set initial values
        protected BaseEntity()
        {
            CreatedDate = DateTime.UtcNow;
            CreatedBy = "Some default value or logged-in user's name";
            ModifiedDate = DateTime.UtcNow;
            ModifiedBy = "admin";
        }

        // Method to update modification information
        public void UpdateModificationInfo(string modifiedBy)
        {
            ModifiedDate = DateTime.UtcNow;
            ModifiedBy = "admin";
        }
    }
}
