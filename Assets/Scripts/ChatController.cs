using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatController : MonoBehaviour {

    public string[][] Messages = {
        new string[] {"Error", "If you're seeing this, chances are one of the two of us did something wrong, if you know what I mean.", "0"},
        new string[] {"Old Man", "Oh, hello! It's not too often that I see Umbral Orbs up here!", "Recently it's been getting <color=orange>quite dangerous</color> up here. You might want to take <color=orange>this.</color>", "/givedrill", "I don't really need it, so you can keep it. Anyway, good luck!", "2"},
        new string[] {"Old Man", "If you're interested, there might be something <color=orange>across that bridge over there</color>. Anyway, good luck!", "2"},
        new string[] {"Sign", "/centrealign", "<color=yellow>WARNING</color>", "/leftalign", "Recently has been reported that <color=orange>snipers</color> have been settling in certain areas in the vicinity.", "If you see a <color=orange>laser</color>, quickly <color=orange>hide behind a wall</color> or similar to avoid being shot.", "Have a safe day, and remember, ALL RED FOR GOOD HEALTH.\n\t--Island management", "3"},
        new string[] {"Old Man", "Oh, hello! It's an Umbral Orb! You may or may not have noticed, but I have a large number of fireplaces here.", "Well, in my carelessness, I may or may not have <color=orange>spread some fire</color> to a few things on this island.", "I have a device here which can <color=orange>put out these fires</color>, but I can't be bothered to put them out, so you can do it instead.", "/givewatergun", "And if you're wondering, I <i>definitely</i> may or may not be the same guy you just saw a while back, but with the sprite flipped.", "5"},
        new string[] {"Old Man", "You may or may not be wondering why I have so many fireplaces. And I say to you: why <i>don't</i> you have so many fireplaces?", "5"},
        new string[] {"Old Man", "Oh, hello agai- Actually, never mind. This is <i>definitely</i> the first time I've seen you.", "Anyway, I've recently been thinking about a <color=orange>riddle</color> presented to me by a friend long ago. I want to see if you can <color=orange>figure it out.</color>", "/givebucket", "The riddle is: \"There are four <i>definitely</i> random words you must remember: <color=orange>Santa, Sky, Sea, Sunset</color>. May they lead you to great fortune one day.\"",  "I think it might have something to do with the <color=orange>c-</color> Actually, never mind. It's <i>definitely</i> not that.", "7"},
        new string[] {"Old Man", "You want to hear the riddle again? In that case, here it is.", "The riddle is: \"There are four <i>definitely</i> random words you must remember: <color=orange>Santa, Sky, Sea, Sunset</color>. May they lead you to great fortune one day.\"",  "I think it might have something to do with the <color=orange>c-</color> Actually, never mind. It's <i>definitely</i> not that.", "7"},
        new string[] {"Sign", "Here you will be given <color=orange>three questions in turn.</color>. Select the <color=orange>right answer, and you may proceed</color>. Select the <color=orange>wrong answer, and you will suffer the consequences.</color>", "8"},
        new string[] {"Sign", "<color=orange>First question!</color>\nHow many levels have you completed so far?", "<color=orange>Left</color> - 3\n<color=orange>Middle</color> - 4\n<color=orange>Right</color> - 5", "9"},
        new string[] {"Sign", "<color=orange>Second question!</color>\nWhat is the least number of bucket fills required to reach the point you're at?", "<color=orange>Left</color> - 5\n<color=orange>Middle</color> - 6\n<color=orange>Right</color> - 7", "10" },
        new string[] {"Sign", "<color=orange>Final question!</color>\nHow many levels are in the game in total?", "<color=orange>Left</color> - 6\n<color=orange>Middle</color> - 8\n<color=orange>Right</color> - 16", "11" },
        new string[] {"Sign", "<color=orange>Bonus question!</color>\nHow many basins have you seen so far?", "<color=orange>Left</color> - 24\n<color=orange>Middle</color> - 26\n<color=orange>Right</color> - 28", "12" },
        new string[] {"Old Man", "Yes, I see that I am upside-down. You just <i>knew</i> that would be the first thing I said, didn't you?", "Anyway, up ahead behind that wall is <color=orange>full of nasties</color>, so you'll want to take this.", "/givelasershot", "There's one in particular which is <color=orange>absolutely huge</color>, so be careful! I don't want to see you dead! Not that you can die, but still.", "14" },
        new string[] {"Old Man", "Here's a little secret: I'm the same guy that you saw three times before. You're not very amazed by that, are you?", "14" },
        new string[] {"Sign", "Island management is pleased to announce the recent addition of Lasershot targets into the nearby area.", "Simply aim your Lasershot at a red glowing target and you will be teleported to it.", "We hope to see the community making good use of these targets.\n\t--Island management", "15"},
    };

    public int Message;

    void Start() {

    }

    void Update() {

    }
}
