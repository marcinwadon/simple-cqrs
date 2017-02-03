namespace SimpleCQRS.Domain.Task.Entity {
    public class Task {
        public string name { get; }
        public string description { get; }

        public Task(string name, string description) {
            this.name = name;
            this.description = description;
        }
    }
}
