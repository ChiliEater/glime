namespace CodeBrewery.Glime
{
    /// <summary>
    /// This class describes all properties of a single input that an input buffer needs to know.
    /// </summary>
    public class Input
    {
        /// <summary>
        /// Gets the age of the input.
        /// </summary>
        public int Age { get; protected set; }

        /// <summary>
        /// Gets or sets the type of the input.
        /// </summary>
        public InputType InputType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Input"/> class.
        /// </summary>
        /// <param name="type">The type of the input.</param>
        public Input(InputType type)
        {
            Age = 0;
            InputType = type;
        }

        /// <summary>
        /// Increments the age of the input.
        /// </summary>
        public void IncrementAge()
        {
            Age++;
        }
    }
}
