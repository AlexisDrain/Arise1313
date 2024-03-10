# Arise: 1313
# الـنـهـوض ١٣١٣ 
# أرايــز ١٣١٣

# By Alexis Clay

/*
    Variables
*/

VAR confiscateVar = ""

/*
    Novel
*/

=== novel_intro1 ===
# image_redComputer
72 hours until our world is devastated…
The fate of humanity rested on my shoulders. A note that had my handwriting was sent back from the future describes the unholy things that the eldritch invasion will do to the world, as well as how to stop it.
I had 3 days to conduct the correct banishment ritual and halt the eldritch invasion. I only have a vague idea of what the ritual looks like, but I have to try something!
Or, I can at least spare myself the eternal torture with a bullet.
+ [1- Suicide.] -> sayonara
+ [2- Drive to house of worship.] -> novel_intro2

=== novel_intro2 ===
# image_black
Speeding like a bat out of hell, it’s no surprise that I encountered a cop.
After flashing his lights we slow down to the side of the road. He gets out, goes over to my side and starts tapping on my window. He’s threatening to have me arrested.
For all I know, he’s an agent sent by the eldritch invasion. Given the state of the impending doom, I have one obvious option...
+ [1- Shoot the cop.] -> wakeup
+ [2- Reason with the cop.] -> wakeup

/*
    Items
*/
=== selfharm_pencilDull ===
You try sticking the pencil in your eye but it's too dull to cause any harm to your eye or brain.
+ [1- Continue]

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
+ [1- Leave] -> foodGet

=== meeting_3 ===
# image_black
# confiscate
You spend the entire 1-on-1 session relaying the world ending phenomenon.

You: “... and that’s why you need to let me out. I would honestly prefer to have the world end rather than experience what’s going to happen in 2 days.”
Therapist: “Fascinating… Your delusions are consistent. Usually schizophrenic people have holes in their explanations.” {confiscateVar}
+ [“So you don’t believe me?”] -> meeting_3No
+ [“So you’ll let me out?”] -> meeting_3No

=== meeting_3No ===
Therapist: "No."
+ [1- Leave] -> stopNovel

/*
    Dreams
*/

=== dream_0 === // turn to stone
You feel an unnatural weight on your limbs as an unseen force begins the petrification process. The ground beneath you, once soft and yielding, turns into an unforgiving surface that clings to your feet, making every step a struggle. The air thickens with an unsettling stillness, and an eerie silence surrounds you, broken only by the distant echoes of your own footsteps.
As you desperately try to escape, your movements become slower, more laborious. Your skin starts to take on a cold, stony texture, and a creeping numbness spreads through your body. Panic sets in as you realize that your very essence is being transformed into unfeeling stone.
+ 1- Wake up. -> wakeup

=== dream_1 === // Family replaced by clones
You wake up to a world that seems eerily familiar yet unsettlingly different. As you navigate your once-familiar home, a sinister realization takes hold – your family has been replaced by emotionless, identical clones. Their faces bear an uncanny resemblance to your loved ones, but their eyes lack warmth, their voices devoid of genuine emotion.

The air is heavy with an unnatural stillness as these doppelgangers move through the house, mimicking the routines and gestures of your family members with an unsettling precision. Conversations are stilted and void of genuine connection, each interaction leaving you with a sense of profound alienation.
+ 1- Wake up. -> wakeup

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

=== wakeup === // only one tag at a time
# closeNovel
-> END