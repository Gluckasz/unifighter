using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Constants
{
    public const int MAX_CAPACITY = 99; // maximal deck size
}
public class DeckStack
{
    // All deck elements
    private int capacity; // maximum amount of cards that can be at the same time in deck, adjustable in Constants class
    private int size; // amount of cards currently in deck
    private int[] array; // whole deck, containing only cards' ID

    // Constructor
    public DeckStack()
    {
        capacity = Constants.MAX_CAPACITY;
        size = 0;
        array = new int[Constants.MAX_CAPACITY];
        for (int i = 0; i < Constants.MAX_CAPACITY; i++)
        {
            array[i] = 0; // removing all trash data from deck
        }
    }

    // Adding new card to the deck
    public int addCard(int id)
    {
        if (size >= capacity)
        {
            return -1; // not enough space in deck
        }

        array[size] = id;
        size++;

        return 0; // card added
    }

    public int removeCard(int index)
    {
        if (index < 0 || index >= size)
        {
            return -1; // wrong index, shouldn't occure but for safety
        }

        for (int i = index; i < size - 1; i++)
        {
            array[i] = array[i + 1];
        }

        array[size] = 0;
        size--;

        return 0; // card removed
    }
}
