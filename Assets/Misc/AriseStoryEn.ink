# Arise: 1313
# الـنـهـوض ١٣١٣ 
# أرايــز ١٣١٣

# By Alexis Clay

// there's a bug where a knot that has only one sentence repeats its tags like in === telephone_noone ===

/*
    Variables
*/

VAR confiscateVar = ""
VAR finalMeal = ""

/*
    Novel
*/

=== novel_intro1 ===
# image_redComputer
72 hours until our world is devastated…
The fate of humanity rests on my shoulders. A note that had my handwriting was sent back from the future that describes the unholy things that the eldritch invasion will do to the world, as well as how to stop it.
I have 3 days to conduct the correct banishment ritual and halt the eldritch invasion. I only have a vague idea of what the ritual looks like, but I have to try something!
Or, I can at least spare myself the eternal torture.
+ [1- Suicide.] -> sayonara
+ [2- Drive to house of worship.] -> novel_intro2

=== novel_intro2 ===
# image_black
Speeding like a bat out of hell, it’s no surprise that I encountered a cop.
After flashing his lights we slow down to the side of the road. He gets out, goes over to my side and starts tapping on my window. He’s threatening to have me arrested.
For all I know, he’s an agent sent by the eldritch invasion. Given the state of the impending doom, I have only one obvious option...
+ [1- Grab the cop's gun.] -> novel_angryCop1
+ [2- Reason with the cop.] -> novel_angryCop2


=== novel_angryCop1 ===
# image_black
Time was running out and every second mattered. With my heart pounding, I execute a harrowing decision.
I reach for the cop’s handgun, part of me thinks that my hand will go through him, but no. I feel him. The cop is in as much disbelief as I am... until the shock passes through him.
The cop whips me with his pistol, then he starts stomping me on the ground until I pass out. Later, I wake up in his cruiser, on the way to an asylum.
+ [1- Continue.] -> asylum1

=== novel_angryCop2 ===
# image_black
The cop fails to see my side of the conversation. I beg him to leave me until I perform the ritual. I also show him the letter from my future-self as evidence. He looks very disturbed by the content, but from his perspective it's the rambling of a madman. 
After he notices a phrase in the paper that mentions a need to sacrifice a living being, he has me arrested under pretense of self-harm. He drives me to a psychiatric hospital.
+ [1- Continue.] -> asylum1

=== asylum1 ===
# image_black
The letter from my future-self DID NOT mention the cop, or that I will be committed in an asylum. 
Then why did my future-self not write about it? Did it not happen to them? In any case, I cannot do anything about it. I’m going to an asylum. The fate of the universe doesn’t rest with me anymore… Or, maybe the incantation can still be performed here?
I arrive through a one-way elevator to the psych ward. The doors shut behind me. This could be where I will spend the last few days of my life.
+ [1- Continue.] -> stopNovel

/*
    Minor characters
*/
=== nursedesk_3 ===
# image_black
The nurse says: "Welcome. Welcome to New Dawn. We were expecting you at our humble psychiatric floor."
She continues: "I suggest getting food first, then you have the option of going to group or talking to a therapist 1-on-1."
+ [1- Leave.] -> stopNovel

=== bystander_1 ===
# image_black
You approach a sitting patient.
He yells past you, unanounced:
"Apple juice is piss!"
"Apple juice is piss!"
"Apple juice is deluxe, demon piss!"
+ [1- "Ok..." Leave.] -> stopNovel

/*
    banishment ritual
*/
=== ritual_0 ===
# image_black
Tonight is the night. The ritual must be followed as described by the letter sent to me from the future.
I must do step 1 and 2 before starting. I could do step 3 during the ritual.
+ [1- Delay The Ritual.] -> stopNovel
+ [2- Start The Ritual.] -> ritual_step1

// Step 1
=== ritual_step1 ===
# image_black
With trembling hands, I enacted the banishment ritual.
Step One: Dialing the number: 69624-1059226
+ [1- Continue.] -> ritual_step1_check

=== ritual_step1_check ===
# checkStep1
-> END

=== ritual_step1_correct ===
# image_black
I have dialed the number correctly the past day.
+ [1- Continue.] -> ritual_step2

=== ritual_step1_incorrect ===
# image_black
I forgot to dial it before the ritual.
+ [1- Continue.] -> ritual_step2

// Step 2
=== ritual_step2 ===
# image_black
# updateMealString
Step Two: The Last Meal: Apple juice and meat.
The last meal I had was:
{finalMeal}
+ [1- Continue.] -> ritual_step2_check

=== ritual_step2_check ===
# checkStep2
-> END

=== ritual_step2_correct ===
# image_black
My last meal matches the second ritual step meal.
+ [1- Continue.] -> ritual_step3

=== ritual_step2_incorrect ===
# image_black
My last meal DOES NOT match the second ritual step meal.
+ [1- Continue.] -> ritual_step3

// Step 3
=== ritual_step3 ===
# image_black
Step Three: The Sacrifice.
+ [1- Continue.] -> ritual_step3_check

=== ritual_step3_check ===
# checkStep3
-> END

=== ritual_step3_pet ===
# image_black
I have blood from the cat I killed earlier.
+ [1- Continue.] -> ritual_step2

=== ritual_step3_nopet ===
# image_black
I must do the sacrifice now.
+ [1- Suicide.] -> ritual_total
+ [2- Do not suicide.] -> ritual_total

=== ritual_total ===
# image_black
The ritual, in total, is correct.
+ [1- Continue.] -> stopNovel

/*
    Items
*/
=== selfharm_pencilDull ===
# image_black
You try sticking the pencil in your eye but it's too dull to cause any harm to your eye or brain.
+ [1- Continue.] -> stopNovel

=== telephone_noone ===
# image_black
# sfx_phoneUp
You pick up the phone receiver. After thinking, you do not have anyone on mind to call.
You put the receiver back. // there's a bug where a knot that has only one sentence repeats its tags, so we add another sentence here.
+ [1- Leave.] -> stopNovel

/*
    Activities
*/
=== breakfast_3 ===
# image_black
"Last call for breakfast! It’s not too late to have breakfast at 2PM!" says Chef Ratsy.
\*She acknowledges you*
"Hello sugar cube, here’s your food for the day. Oh, and before I forget, you should complete the food questionnaire for what you want to eat later."
\*You get food, a new pencil, and a paper to fill out*
+ [1- Fill out questionnaire] -> foodGetAndQuestionnaire

=== dinner_3 ===
# image_black
"I hope you're starving! Plenty of food to go around."
\* Chef Ratsy hands you your dinner*
+ [1- Leave.] -> foodGet

// first therapist meeting
=== meeting_3 ===
# image_black
# confiscate
You spend the entire 1-on-1 session relaying the world ending phenomenon.
You: “... and that’s why you need to let me out. I would honestly prefer to have the world end rather than experience what’s going to happen in 2 days.”
Therapist: “Fascinating… Your delusions are consistent. Usually schizophrenic people have holes in their explanations.” {confiscateVar}
+ [1- “So you don’t believe me?”] -> meeting_3No
+ [2- “So you’ll let me out?”] -> meeting_3No
=== meeting_3No ===
Therapist: "No."
+ [1- Leave.] -> meeting_3No2
=== meeting_3No2 ===
At the conclusion of the therapy activity, you go back to your room.
+ [1- Continue.] -> setTimeEve

/*
    Dreams
*/

=== dream_0 === // turn to stone
You feel an unnatural weight on your limbs as an unseen force begins the petrification process. The ground beneath you, once soft and yielding, turns into an unforgiving surface that clings to your feet, making every step a struggle. The air thickens with an unsettling stillness, and an eerie silence surrounds you, broken only by the distant echoes of your own footsteps.
As you desperately try to escape, your movements become slower, more laborious. Your skin starts to take on a cold, stony texture, and a creeping numbness spreads through your body. Panic sets in as you realize that your very essence is being transformed into unfeeling stone.
+ [1- Wake up.] -> wakeupToMorning

=== dream_1 === // Family replaced by clones
You wake up to a world that seems eerily familiar yet unsettlingly different. As you navigate your once-familiar home, a sinister realization takes hold – your family has been replaced by emotionless, identical clones. Their faces bear an uncanny resemblance to your loved ones, but their eyes lack warmth, their voices devoid of genuine emotion.

The air is heavy with an unnatural stillness as these doppelgangers move through the house, mimicking the routines and gestures of your family members with an unsettling precision. Conversations are stilted and void of genuine connection, each interaction leaving you with a sense of profound alienation.
+ [1- Wake up.] -> wakeupToMorning

/* 
    special functions 
*/
=== foodGetAndQuestionnaire === // only one tag at a time
# foodGetAndQuestionnaire
-> END

=== foodGet === // only one tag at a time
# foodGet
-> END

=== sayonara === // only one tag at a time
# sayonaraStart
-> END

=== stopNovel === // only one tag at a time
# closeNovel
-> END

=== setTimeEve === // only one tag at a time
# setTimeEve
-> END

=== wakeupToNight === // only one tag at a time
# playerWakeupToNight
-> END

=== wakeupToMorning === // only one tag at a time
# playerWakeupToMorning
-> END