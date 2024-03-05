# Arise: 1313
# الـنـهـوض ١٣١٣ 
# أرايــز ١٣١٣

# By Alexis Clay

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
    Activities
*/
=== breakfast_3 ===
# image_black
Last call for breakfast! It’s not too late to have breakfast at 2PM!
\*Chef Ratsy acknowledges you*
Hello dear, here’s your food for the day. Oh, and before I forget, you should complete the food questionnaire for what you want to eat later.
\*You get food and a paper*
+ [1- Fill out questionnaire] -> foodGet

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
=== foodGet ===
# foodGet
-> END

=== sayonara ===
# sayonaraStart
-> END

=== wakeup ===
# closeNovel
-> END