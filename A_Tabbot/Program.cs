using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Tabbot
{
    class Program
    {
        static int notesNumber, handPosition, topFret;
        static int lowestString, highestString;
        static int lowestPosition, highestPosition;
        static int fewestNotes, mostNotes;
        static int maxSlide;
        static float stretchFactor;
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            //Initialise params
            Parameters();

            //Initialise notes array
            notesNumber = rnd.Next(fewestNotes, mostNotes + 1);
            Note[] notes = new Note[notesNumber];

            Console.WriteLine(notesNumber + " notes in riff.");
            Console.WriteLine("notes array initialised to length " + notes.Length);

            //Choose starting left hand position
            handPosition = rnd.Next(lowestPosition, highestPosition + 1);
            topFret = (int)((float)handPosition * stretchFactor) + 3;

            Console.WriteLine("Frets available are " + handPosition + " to " + topFret + ".");

            AssignBeats(notes);

            //Iterate over notes in riff to choose fret number for each
            for (int i = 0; i < notesNumber; i++)
            {
                notes[i].fret = rnd.Next(handPosition, topFret + 1);
                Console.WriteLine("Adding note " + i + " at fret " + notes[i].fret + " on quaver " + notes[i].beat + ".");
            }
        }

        static void Parameters()
        {
            lowestString = 1;
            highestString = 6;      //How many guitar strings?
            lowestPosition = 1;
            highestPosition = 6;    //How far up fretboard to allow left hand (first finger on this fret)?
            fewestNotes = 3;
            mostNotes = 8;          //How many notes in the riff?
            maxSlide = 3;           //Maximum number of frets slid across in a slide.
            stretchFactor = 1.15f;  //How much moving up the fretboard increases number of frets in reach.
        }

        static Note[] AssignBeats(Note[] notes)
        {
            for (int i = 0; i < notesNumber; i++) {
                int beatFactor = rnd.Next(0, 15);
                if (beatFactor < 4) { notes[i].beat = 1; }
                else if (beatFactor < 8) { notes[i].beat = 5; }
                else if (beatFactor < 10) { notes[i].beat = 3; }
                else if (beatFactor < 12) { notes[i].beat = 7; }
                else if (beatFactor < 13) { notes[i].beat = 2; }
                else if (beatFactor < 14) { notes[i].beat = 4; }
                else if (beatFactor < 15) { notes[i].beat = 6; }
                else if (beatFactor < 16) { notes[i].beat = 8; }
            }

            Array.Sort<Note>(notes, (x,y) => x.beat.CompareTo(y.beat));

            return notes;
        }


    }

    struct Note {
        public int beat, gString, fret;
    }
}
