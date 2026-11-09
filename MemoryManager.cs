/*******************************************************************
 * Name: Anthony Seldon
 * Date: November 8, 2026
 * Assignment: SDC220 Final Calculator Project
 *
 * MemoryManager class.
 * This class stores up to 10 numeric values and allows users
 * to display and recall previously stored values.
 *******************************************************************/

using System;
using System.Collections.Generic;

public class MemoryManager
{
    // Private List stores calculator memory values
    private List<double> memoryValues;

    // Constructor initializes memory
    public MemoryManager()
    {
        memoryValues = new List<double>();
    }

    // Returns the number of stored values
    public int Count
    {
        get { return memoryValues.Count; }
    }

    // Stores a value if memory has available space
    public bool StoreValue(double value)
    {
        if (memoryValues.Count >= 10)
        {
            return false;
        }

        memoryValues.Add(value);
        return true;
    }

    // Recalls a stored value using its position
    public double RecallValue(int position)
    {
        if (position < 1 || position > memoryValues.Count)
        {
            throw new ArgumentOutOfRangeException(
                "position",
                "That memory position does not exist.");
        }

        return memoryValues[position - 1];
    }

    // Displays all stored memory values
    public void DisplayMemory()
    {
        if (memoryValues.Count == 0)
        {
            Console.WriteLine("Memory is empty.");
            return;
        }

        Console.WriteLine("Stored Memory Values:");

        for (int i = 0; i < memoryValues.Count; i++)
        {
            Console.WriteLine(
                "{0}. {1:F2}", i + 1, memoryValues[i]);
        }
    }

    // Clears all stored memory values
    public void ClearMemory()
    {
        memoryValues.Clear();
    }
}