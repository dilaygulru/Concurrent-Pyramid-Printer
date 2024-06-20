#### Pyramid Pattern Printer

#### Project Description:
This project develops a concurrent pyramid pattern printer. It is designed to handle requests for printing patterns shaped in pyramids using either stars or alphabet characters. The application is built on concurrency techniques to manage simultaneous print requests efficiently.

#### Features:
- **Concurrency Handling:** Manages multiple print tasks concurrently, ensuring that same pattern types are processed simultaneously.
- **Dynamic Input Handling:** Reads print requests from an input file and handles them based on specified attributes such as pattern type and size.
- **Pattern Generation:** Capable of generating two types of patterns:
  - **Star Pattern:** Uses asterisks (`*`) to form pyramid patterns.
  - **Alphabet Pattern:** Uses sequential letters of the alphabet to form pyramid patterns.
- **Log Management:** Generates detailed logs for each print task, documenting task start and end times, pattern types, and sizes.
- **Output Management:** Outputs the generated pyramid patterns to a specified file for review.

#### Usage:
1. Ensure the input, output, and log file paths are correctly set in the code.
2. Compile and execute the program in an environment that supports C#.
3. Review the generated output and log files to verify the patterns and process flows.

#### Requirements:
- C# compiler or a compatible IDE that supports C# development.
- Basic understanding of file operations and concurrency in C#.

#### System Operations:
- **Input File Processing:** Reads the request time, pattern type, and size from a structured input file.
- **Pattern Printing:** Calculates print durations based on the size (square of the size in milliseconds) and manages concurrent processing based on pattern type.
- **Output and Logging:** Outputs the pyramid patterns and logs operations with timestamps indicating the duration of each print task.

#### Example Outputs:
- **Star Pattern of Size 4:** Generates a 4-level pyramid using `*`.
- **Alphabet Pattern of Size 3:** Generates a 3-level pyramid using `A`, `B`, `C`.

#### Developer Guide:
- **Adjusting Patterns:** Modify `GenerateStarPattern` and `GenerateAlphabetPattern` functions to alter pattern designs.
- **Concurrency Tuning:** Review thread management for optimizing processing of concurrent requests.
