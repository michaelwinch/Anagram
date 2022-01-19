# Anagram

This program groups a list of words by if they are anagrams of each other and outputs them to console. Included in the zip file is the source code and executable.

It is a command line tool and must be run with the file path as an argument in the format:

`Anagram.exe --filepath "C:\file.txt"`

This program has been written in F#, using NUnit for the unit tests and CommandLineParser for parsing the command line arguments.

## Complexity
The program can be split into two parts - the loop which gets all words of the same length, and the grouping function which groups words by anagrams.

The loop has time complexity O(1) as it is only inserting items and space complexity O(n).

The grouping function works by sorting the characters of each word in alphabetic order and comparing them. Grouping itself has time complexity O(n) but the sort is likely to have time complexity O(n log (n)), therefore should be considered O(n log (n)). This will also have space complexity O(n).

## Data Structures
I have used seq (F# alias for IEnumerable) to store the words to be grouped. This is because it is immutable and memory efficient as only one element is loaded at a time.

## Future improvements
Given more time I would investigate how I could better unit test the program loop which is responsible for reading from the file and passing groups of words to the grouping function. I could use a different unit testing library to ensure that groupAnagrams is called before the loop is called with the next length of word. This would  both prove that *all* words of the same length are being grouped and that memory is being freed up before the next group is loaded.

Another change in a similar fashion would be to mock the input file.
