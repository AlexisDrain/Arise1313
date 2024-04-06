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
I arrive through a one-way elevator to the psych ward. They shackle an ID bracelet on my wrist. The doors shut behind me.
This could be where I will spend the last few days of my life.
+ [1- Continue.] -> start3DGame

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
You approach a sitting patient. He yells at the sky:
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
Step One: Dialing the number: 69624-105-9226
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

=== telephone_3 ===
# image_black
# sfx_phoneUp
You pick up the phone receiver.
Who do you want to call? // there's a bug where a knot that has only one sentence repeats its tags, so we add another sentence here.
+ [1- Call parents.] -> telephone_parents
+ [2- Leave.] -> telephone_noone
=== telephone_noone ===
After thinking, you do not have anyone on mind to call.
You put the receiver back.
+ [1- Leave.] -> stopNovel
=== telephone_parents ===
# image_black
Your relationship with your parents is normally strained, but talking about your suicidal ideation and your hospitalization brings anyone together.
+ [1- Leave.] -> stopNovel

=== telephone_2 ===
# image_black
# sfx_phoneUp
You pick up the phone receiver.
Who do you want to call? // there's a bug where a knot that has only one sentence repeats its tags, so we add another sentence here.
+ [1- Call sibling.] -> telephone_sibling
+ [2- Leave.] -> telephone_noone
=== telephone_sibling ===
# image_black
When you explain the world ending phenomenon and plead to your sibling to let you out, they just say: “Are you sure you’re taking your meds?”
+ [1- Leave.] -> stopNovel

=== telephone_night ===
# image_black
# sfx_phoneUp
You pick up the phone receiver.
Who do you want to call? // there's a bug where a knot that has only one sentence repeats its tags, so we add another sentence here.
+ [1- Call parents.] -> telephone_night_parents
+ [2- Leave.] -> telephone_noone
=== telephone_night_parents ===
# image_black
Despite the hour being almost midnight, your parents are awake and concerened about your health. They were thinking of you when you called.
They make you promise not to go back to the hospital.
+ [1- Leave.] -> stopNovel

/*
    Activities
*/
=== breakfast_3 ===
# image_black
"Hello sugar cube, here’s your food for the day. Oh, and before I forget, you should complete the food questionnaire for what you want to eat later."
You get food, a new pencil, and a paper to fill out
// commented out astrix: \*You get food, a new pencil, and a paper to fill out*
+ [1- Fill out questionnaire] -> foodGetAndQuestionnaire

=== dinner_3 ===
# image_black
"I hope you're starving! Plenty of food to go around."
Chef Ratsy hands you your dinner.
+ [1- Leave.] -> foodGet

// first therapist meeting
=== meeting_1 ===
You: “Do you see yellow text while closing your eyes?”
Therapist Rose: “Like… thinking of words and then imagining them in physical form? I think everyone does? What does the yellow text say by the way?”
You: “It’s says ‘You’re insane if you trust her.’”
Therapist: “Ha-ha. Nothing un-insane about a visual hallucination telling you that you're not insane.”
+ [1- Continue.] -> meeting_1_2
=== meeting_1_2 ===
Therapist: "I will let you in on a secret. There IS a step in the ritual that I know of:"
"Step Three requires a sacrifice. Of you or of someone else. That's all I'm going to say. And good luck getting that in the less than 3 days that this world has."
She shifts her legs and continues: "My real employer provides me with $2000 per hour to... humor you. There's a wagering contest going on. And it looks like you're on the losing side already."
She leaves. Leaving you absolutely stunned in your seat. A while later you go back to your room to think.
+ [1- Continue.] -> setTimeFollowingTimePeriod

// second therapist meeting
=== meeting_2 ===
# image_black
This is a different therapist than before. She does not recognize the previous therapist. You spend the entire 1-on-1 session relaying the world ending phenomenon.
You: “... and that’s why you need to let me out. I would honestly prefer to have the world end rather than experience what’s going to happen in 2 days.”
Therapist: “Fascinating… Your delusions are consistent. Usually schizophrenic people have holes in their explanations.”
+ [1- “So you don’t believe me?”] -> meeting_2_2
+ [2- “So you’ll let me out?”] -> meeting_2_2
=== meeting_2_2 ===
Therapist: "No."
+ [1- Leave.] -> meeting_2_3
=== meeting_2_3 ===
At the conclusion of the therapy activity, you go back to your room.
+ [1- Continue.] -> setTimeFollowingTimePeriod

// third therapist meeting
=== meeting_3 ===
# image_black
This is second therapist you met. The one that claimed they didn't know about the end of the world.
She talks in a way that you think SHE has a mental illness. Always has to rattle off, never leaving you a chance to speak your turn.
"Well, well, well! How are we feeling today, my dear inmate? Oh, I must say, I've been having the most intriguing thoughts about the interconnectedness of the universe. It's like this vast web of emotions and energy, you know? Speaking of which, how do you feel today? Don't hold back, spill the beans! Let's dissect those feelings and unravel the mysteries of your psyche."
You: "Uh, well, I guess I've been feeling a bit..."
"Fantastic! Feelings are like puzzle pieces, scattered across the canvas of our minds. Now, have you been hearing any voices lately? Oh, the symphony of voices in my head, they're like a choir singing the song of existence. Sometimes I wonder if they're trying to communicate some profound truth with me. But I digress! Your turn, my dear patient, any voices whispering sweet nothings in your ears?"
You sigh internally, and talk robotically through the appointment.
+ [1- Continue.] -> meeting_3_2
=== meeting_3_2 ===
At the conclusion of the therapy activity, you go back to your room.
+ [1- Continue.] -> setTimeFollowingTimePeriod

// first group meeting
=== group_1 ===
# image_black
"Alright class! Everyone, grab a seat from the kitchen and sit around a circle."
It's a fairly standard group therapy session. Everyone introduces themselves by name and a fun fact about them. The group leader speaks like a bro - you feel like you could be friends with him outside of the hospital. There's also a "musical therapist" who plays guitar songs on demand.
It's actually pretty nice being here!
+ [1- Continue.] -> checkBrother
=== checkBrother ===
# checkBrother
-> END
=== hasBrother ===
# image_black
At the conclusion of the group, a man bumps into you.
He says: “Step One is to call a number! It’s on your wrist!”
You look at the ID bracelet given to you on entrance to the hospital. The ID number reads: 69624-105-9226. Does this number mean anything significant?
He gets tackled by two orderlies built like bulldozers. “I’M YOUR BROTHER!” He says, as he gets dragged away and into the elevator. “I love you very much!” he says.
You don’t know who he is or where he will be taken.
"He says that to everyone," the group leader claims, smiling knowingly.
+ [1- Continue.] -> setTimeFollowingTimePeriod

// second group meeting
=== group_2 ===
During the group therapy, someone mentions needing to leave the hospital early: “I have to get to work! I’ll be fired otherwise!”
The group leader responds: “Your life is more important than your welfare. We cannot trust you to go to work. We cannot even trust you to eat without supervision! You leave the hospital early by showing us signs of you getting better, getting less… “weird”.”
You: “How long do people stay here at this hospital?”
“For the real basket cases? 3 months to a year. For most? As few as 3 to 5 days...”
You: “So, you’re saying I’m leaving in two days?”
“HAH. I see why they call you kooky!”
+ [1- Continue.] -> group_2_2
=== group_2_2 ===
At the conclusion of the group activity, you go back to your room.
+ [1- Continue.] -> setTimeFollowingTimePeriod


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

=== start3DGame === // only one tag at a time
# start3DGame
-> END

=== stopNovel === // only one tag at a time
# closeNovel
-> END

=== setTimeFollowingTimePeriod === // in case an event forwards the time but we're not sure if it's morning or evening.
# setTimeFollowingTimePeriod
-> END

=== setTimeEve === // only one tag at a time
# setTimeEve
-> END
=== setTimeMidnight === // only one tag at a time
# setTimeMidnight
-> END

=== wakeupToNight === // only one tag at a time
# playerWakeupToNight
-> END

=== wakeupToMorning === // only one tag at a time
# playerWakeupToMorning
-> END