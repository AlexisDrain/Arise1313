﻿# Arise: 1313
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
# blueText
48 hours until our world is devastated…
The fate of humanity rests on my shoulders. A note that has my handwriting was sent back from the future. It describes the unholy things that the eldritch invasion will do to the world, as well as how to stop it.
I have 2 days to conduct the correct banishment ritual and halt the eldritch invasion. I only have a vague idea of what the ritual looks like, but I have to try something!
Or, I can at least spare myself the eternal torture.
+ [1- Suicide.] -> sayonara
+ [2- Drive to house of worship.] -> novel_intro2

=== novel_intro2 ===
# image_black
# blueText
Speeding like a bat out of hell, it’s no surprise that I encountered a cop.
After flashing his lights we slow down to the side of the road. He gets out, goes over to my side and starts tapping on my window. He’s threatening to have me arrested.
For all I know, he’s an agent sent by the eldritch invasion. Given the state of the impending doom, I have only one obvious option...
+ [1- Grab the cop's gun.] -> novel_angryCop1
+ [2- Reason with the cop.] -> novel_angryCop2


=== novel_angryCop1 ===
# image_black
# blueText
Time is running out and every second matters. With my heart pounding, I execute a harrowing decision.
I reach for the cop’s handgun, part of me thinks that my hand will go through him, but no. I feel him. The cop is in as much disbelief as I am... until the shock passes through him.
The cop whips me with his pistol, then he starts stomping me on the ground until I pass out. Later, I wake up in his cruiser, on the way to an asylum.
+ [1- Continue.] -> asylum1

=== novel_angryCop2 ===
# image_black
# blueText
The cop fails to see my side of the conversation. I beg him to leave me until I perform the ritual. I also show him the letter from my future-self as evidence. He looks very disturbed by the content, but from his perspective it's the rambling of a madman. 
When I tell him the ritual requires a sacrifice of a living being, he has me arrested under pretense of self-harm. He drives me to a psychiatric hospital.
+ [1- Continue.] -> asylum1

=== asylum1 ===
# image_black
# sanityDown
# blueText
The letter from my future-self DID NOT mention the cop, or that I will be committed in an asylum. 
Then why did my future-self not write about it? Did it not happen to them? In any case, I cannot do anything about it. I’m going to an asylum. The fate of the universe doesn’t rest with me anymore… Or, maybe the incantation can still be performed here?
I arrive through a one-way elevator to the psych ward on the 13th floor. They shackle an ID bracelet on my wrist. The doors shut behind me.
This could be where I will spend the last few days of my life.
+ [1- Continue.] -> start3DGame

/*
    Nurse desk / tutorial girl
*/

// Day 1 morning
=== nursedesk_1 ===
# image_black
The nurse says: "Welcome. Welcome to New Dawn. We were expecting you at our humble psychiatric floor."
She continues: "I suggest getting breakfast first, then you have the option of going to group or talking to a therapist 1-on-1."
"Don't forget, if you don't know where to go, you should come talk to me!"
+ [1- Leave.] -> stopNovel

// Day 1 + Day 2 Eve
=== nursedesk_2_5 ===
# image_black
The nurse says: "You should get dinner, then you might want to go to the chaplain in the prayer room, he want to talk to you! It's the last room on the hallway to my right."
"After that, if you've already tried group then you should go to the therapist. Or vice versa."
"Don't forget, if you don't know where to go, you should come talk to me!"
+ [1- Leave.] -> stopNovel

// Day 2 Morn
=== nursedesk_4 ===
# image_black
The nurse says: "You should get breakfast, then you might want to go to the chaplain in the prayer room, he want to talk to you! It's the last room on the hallway to my right."
"After that, if you've already tried group then you should go to the therapist. Or vice versa."
"Don't forget, if you don't know where to go, you should come talk to me!"
+ [1- Leave.] -> stopNovel

// Day 1 Night
=== nursedesk_3 ===
# image_black
The nurse says: "It's waaay past bedtime for you. You should go to your room, it's the blue door on your right."
"If you can't sleep, the chaplain is praying. I'm sure he'd like some company."
"Don't forget, if you don't know where to go, you should come talk to me!"
+ [1- Leave.] -> stopNovel

// Day 2 Night
=== nursedesk_6 ===
# image_black
The nurse says: "Tonight is the night. Go to the prayer room, stat! Or else..."
+ [1- Leave.] -> stopNovel

/*
    Minor characters
*/

=== piano_1 ===
Peering past the polished piano, patient Philipp plays passionately. To your surprise, he's playing without reading sheet music!
Someone asks him to play a Zelda song. "Patience," he says. He’s too concentrated on the current piece.
+ [1- Leave.] -> stopNovel

=== piano_2 ===
Peering past the polished piano, patient Philipp plays passionately. To your surprise, he's playing without reading sheet music!
He’s beaming with pride at playing this song. He probably wrote it.
+ [1- Leave.] -> stopNovel


=== bloodpressure_1 ===
# image_black
You see a bubbly young nurse with flowing blonde hair, chewing bubble gum.
She says, "Hi, I'm doing blood pressure rounds. It's like, super important, you know? Let me take yours."
+ [1- Wrap cuff around your arm.] -> bloodpressure_check
+ [2- Leave.] -> stopNovel

=== bloodpressure_check ==
# checkBloodPressure
-> END

=== bloodpressure_good ===
# sanityUp
The machine gives you a fractional number which you immediately forget.
"Oh yay, looking good! Your BP is totally on point, like, seriously awesome!"
Despite your stress, you manage to keep it cool enough that the machine gives you a normal figure.
+ [1- "Ok..." Leave.] -> stopNovel

=== bloodpressure_bad ===
# sanityDown
The machine gives you a fractional number which you immediately forget.
"You seem so stressed!" She gives you a frown so animated it looks cartoonish. "Please take it easy!"
You can't take it easy. If people find out you're stressed they might keep you here forever.
+ [1- "Ok..." Leave.] -> stopNovel

=== bystander_1 ===
# image_black
You approach a patient laying on the ground. He yells at the sky:
"Apple juice is piss!"
"Apple juice is piss!"
"Apple juice is deluxe, demon piss!"
+ [1- "Ok..." Leave.] -> stopNovel

=== bystander_2 ===
# image_black
You approach a patient whispering to himself. You feel sorry for his roommate.
"You know, have you ever thought about how butterflies are like tiny fairies with wings? I mean, wings! Magical flutters in the air, just like my thoughts, you know? Thoughts, thoughts, thoughts buzzing like bees in my brain. But seriously, have you ever tried counting stars and wondering if each one is a secret message from aliens? I did that last night, or was it the night before? Time is a slippery eel, my friend, slipping through our fingers like sand in an hourglass. And speaking of time, did you know that time travel is theoretically possible? I read it on the internet, the vast ocean of knowledge and misinformation. The internet, like a digital spider weaving a web of connections, just like the voices in my head. Voices, voices, whispering secrets and conspiracies. Do you believe in conspiracies? I do, sometimes, especially when the moon is full and the shadows dance on the walls. Shadows, shadows, morphing into creatures from another dimension. Ever felt like you're living in a parallel universe? Like, what if reality is just a hologram projected by interdimensional beings? Beings, beings, watching us like actors on a cosmic stage. And have you noticed how the walls have ears? Not literally, of course, but metaphorically, absorbing the vibrations of our existence. Existence, existence, a puzzle with missing pieces. I once tried solving it with a Rubik's Cube, but the colors kept changing, like a psychedelic kaleidoscope. Kaleidoscope, kaleidoscope, turning reality into a colorful whirlwind. Whirlwind, whirlwind, spinning, spinning, spinning... Hey, are you still awake? I can't sleep, you know? Sleep, sleep, a realm of dreams and nightmares. Nightmares, nightmares, lurking in the shadows of the mind. Mind, mind, a labyrinth of thoughts and echoes. Echoes, echoes, bouncing off the walls of my consciousness. Consciousness, consciousness, an enigma wrapped in a riddle. Riddle, riddle, can you solve it? Solve, solve, like a mathematical equation with infinite variables. Variables, variables, shifting like the sands of time. Time, time, slipping away, slipping away... But seriously, have you ever thought about how butterflies are like tiny fairies with wings?
+ [1- Leave.] -> stopNovel

=== bystander_3 ===
# image_black
# sanityUp
# giveChocolate
Nice Nurse: "It’s very late for you sweetie. Here’s a cup of hot chocolate, but don’t tell anyone I got it for you." She winks and hands you a cup.
"By the way, if you still can't sleep, then call your parents on the public phone. From my experience, parents of patients can't sleep easy either."
+ [1- Thank her and leave.] -> stopNovel

/*
    banishment ritual
*/
=== ritual_0 ===
# image_black
# updateMealString
Tonight is the night. The ritual must be followed as described by the letter sent to me from the future.
You must do step 1 and 2 before starting. You could do step 3 during the ritual.
The last meal you had was:
{finalMeal}
+ [1- Delay The Ritual.] -> stopNovelTeleportPlayerToRitualRoom
+ [2- Start The Ritual.] -> ritual_step1

// Step 1
=== ritual_step1 ===
# image_black
With trembling hands, you and the chaplain enact the banishment ritual.
He orders the seemingly empty prayer room with authority, "the time has come to begin our ritual."
"Step One: Dialing the number: 69624-105-9226"
+ [1- Continue.] -> ritual_step1_check

=== ritual_step1_check ===
# checkStep1
-> END

=== ritual_step1_correct ===
# image_black
You have dialed the number correctly the past day.
+ [1- Continue.] -> ritual_step2

=== ritual_step1_incorrect ===
# image_black
You forgot to dial it before the ritual.
+ [1- Continue.] -> ritual_step2

// Step 2
=== ritual_step2 ===
# image_black
# updateMealString
"Step Two: The Last Meal: Demon piss and flesh. As in, apple juice and meat."
The last meal you had was:
{finalMeal}
+ [1- Continue.] -> ritual_step2_check

=== ritual_step2_check ===
# checkStep2
-> END

=== ritual_step2_correct ===
# image_black
Your last meal matches the second ritual step meal.
+ [1- Continue.] -> ritual_step3

=== ritual_step2_incorrect ===
# image_black
Your last meal DOES NOT match the second ritual step meal.
+ [1- Continue.] -> ritual_step3

// Step 3
=== ritual_step3 ===
# image_black
"Step Three: The Sacrifice."
+ [1- Continue.] -> ritual_step3_check

=== ritual_step3_check ===
# checkStep3
-> END

=== ritual_step3_failedStepOneTwo ===
# image_black
The chaplain says, "the ritual failed. There's no point in doing the Third step."
+ [1- Continue.] -> ritual_step3_failedStepOneTwo2

=== ritual_step3_failedStepOneTwo2 ===
"Dear god! The invasion is real!"
An army of military men lead by a stern, authoritative figure break into the hospital. In seconds that feel much longer, they meet you in the prayer room.
"You have disappointed me for the last time. Hellfire. Eternal Toture. This is the fate of you and other misguided infidels."
+ [1- Continue.] -> ending_bad_ritualIncorrect

=== ritual_step3_checkPet ===
# checkStep3Pet
-> END

=== ritual_step3_pet ===
# image_black
You present the bloodied pencil from the cat you killed earlier.
The chaplin says, "the Third step is complete. I'm somehow glad we didn't have to sacrifice ourselves. I pray for Littlepip's soul."
+ [1- Continue.] -> ritual_totalPet

=== ritual_step3_nopet ===
# image_black
"One of use has to do the sacrifice," the chaplain says. "I am ready to do it, but the only weapon we have is this sharp pencil."
Your gazes meet. "My soul, or yours. I leave you to decide."
+ [1- Sacrifice self.] -> func_ritual_sayonara
+ [2- Sacrifice chaplain.] -> ritual_totalChaplain

=== ritual_totalPet ===
# image_black
With no human life loss, the ritual, in total, has been performed correctly.
+ [1- Finish.] -> ending_good_sacrificePet

=== func_ritual_sayonara ===
# func_ritual_sayonara
-> END

=== ritual_totalSelfCannot ===
# image_black
You are unable to sacrifice yourself.
"I understand," the chaplain says. "It has to be done." He pauses, then he takes the pencil from your hand.
"I will see you in another life," were the chaplain's final words. He sticks the pencil in his eye with a fluid, practiced motion.
The ritual, in total, has been performed correctly.
+ [1- Finish.] -> ending_good_sacrificeSelf

=== ritual_totalSelfCan ===
# image_black
The chaplain looks at you with teary eyes. "You are so... brave. I will hopefully see you in another life."
The pencil penetrates your brain. You are now... dead.
The ritual, in total, has been performed correctly.
+ [1- Finish.] -> ending_good_sacrificeSelf

=== ritual_totalChaplain ===
# image_black
"I will see you in another life," were the chaplain's final words. He sticks the pencil in his eye with a fluid, practiced motion.
He is now... dead.
The ritual, in total, has been performed correctly.
+ [1- Finish.] -> ending_good_sacrificeChaplain

/*
    Items
*/
=== selfharm_pencilDull ===
# image_black
You try sticking the pencil in your eye but it's too dull to cause any harm to your eye or brain.
+ [1- Continue.] -> stopNovel

=== telephone ===
# image_black
# sfx_phoneUp
# checkPhone
-> END

=== telephone_1 ===
You pick up the phone receiver.
Who do you want to call? // there's a bug where a knot that has only one sentence repeats its tags, so we add another sentence here.
+ [1- Call parents.] -> telephone_parents
+ [2- Hang up.] -> telephone_noone
=== telephone_2 ===
You pick up the phone receiver.
Who do you want to call? // there's a bug where a knot that has only one sentence repeats its tags, so we add another sentence here.
+ [1- Call sibling.] -> telephone_sibling
+ [2- Hang up.] -> telephone_noone
// === telephone_calledEveryone ===
// You pick up the phone receiver.
// Who do you want to call? // there's a bug where a knot that has only one sentence repeats its tags, so we add another sentence here.
// + [1- Leave.] -> telephone_noone

=== telephone_noone ===
After thinking, you do not have anyone on mind to call.
You put the receiver back.
+ [1- Leave.] -> stopNovel
=== telephone_parents ===
# image_black
# sanityUp
# boolTrue_calledParentsDay
Your relationship with your parents is normally strained, but opening up about your suicidal ideation and your hospitalization brings anyone together.
+ [1- Hang up.] -> stopNovel

=== telephone_sibling ===
# image_black
# boolTrue_calledSiblingsDay
// # sanityDown
When you explain the world ending phenomenon and plead to your sibling to let you out, they just say: "Are you sure you’re taking your meds?"
+ [1- Hang up.] -> stopNovel

=== telephone_night ===
# image_black
# sfx_phoneUp
You pick up the phone receiver.
Who do you want to call? // there's a bug where a knot that has only one sentence repeats its tags, so we add another sentence here.
+ [1- Call parents.] -> telephone_night_parents
+ [2- Leave.] -> telephone_noone

=== telephone_night_parents ===
# image_black
# sanityUp
# boolTrue_calledParentsNight
Despite the hour being almost midnight, your parents are awake and concerened about your health. They were thinking of you when you called.
They make you promise not to go back to the hospital.
+ [1- Hang up.] -> stopNovel


=== telephone_dialWeirdNumber ===
You pick up the phone receiver.
Who do you want to call? // there's a bug where a knot that has only one sentence repeats its tags, so we add another sentence here.
+ [1- Dial 69624-105-9226] -> telephone_checkWeirdNumber
+ [2- Hang up.] -> telephone_noone
=== telephone_checkWeirdNumber ===
# telephone_checkWeirdNumber
-> END


=== telephone_ritual_wrongDay ===
The voice on the other end carries a weight of familiarity, one you knew from childhood...
"You're supposed to call me TOMORROW!"
The man on the other side of the phone hangs up. No big deal. This won't affect the ritual.
+ [1- Hang up.] -> stopNovel

=== telephone_ritual_rightDay ===
The voice on the other end carries a weight of familiarity, but you don’t remember who it is.
"So you finally called! You better complete the rest of the ritual tonight properly or I will detach your teeth!"
The man on the other side of the phone hangs up.
+ [1- Hang up.] -> stopNovel

/*
    house of worship
*/
=== worship_check ===
# checkWorship
-> END

// first meeting with chaplain
=== worship_intro ===
As you enter the prayer room (and makeshift storage), you see a tall man in a sharp suit.
"I’ve been expecting you. I’m the chaplain of New Dawn. I provide spiritual care no matter your religion."
+ [1- Shake hands.] -> worship_chaplainShakeHands

=== worship_chaplainShakeHands ===
# checkChaplainShakeHands
-> END

// chaplain Morning
=== worship_Morn ===
"Please. Let’s pray together." He sits on one of the rugs.
+ [1- Pray Fajr] -> worship_pray
+ [2- Meditate] -> worship_meditate

// chaplain eve
=== worship_Eve ===
"Welcome to the prayer room. Please. Let’s pray together." He sits on one of the rugs.
+ [1- Pray Dhuhr + Asr] -> worship_pray
+ [2- Meditate] -> worship_meditate

// chaplain night
=== worship_Night ===
"Friend, God is open to prayers at any hour. No matter how late." He sits on one of the rugs.
+ [1- Pray Maghrib + Isha] -> worship_pray
+ [2- Meditate] -> worship_meditate

=== worship_pray ===
# sanityUp
# prayerIncrement
You feel spiritually rejuvenated. You are not alone when God is with you.
+ [1- Leave] -> secondChaplainMeeting_check

=== worship_meditate ===
# sanityUp
# prayerIncrement
Saving the world requires a bit of faith. You muster as much of it as you can while meditating.
+ [1- Leave] -> secondChaplainMeeting_check

=== secondChaplainMeeting_check ===
# checkSecondChaplainMeeting
asdf
+ [asdf] -> END

=== worship_ritualstep ===
// # sanityDownTwice
After your session, the chaplain grips your hand as you're leaving. "Step Three requires a sacrifice. Of you or another living being." he says.
"What?"
"Use a sharp pencil if you have to! It doesn't have to be yourself! I already said too much. Just go now. We can't talk."
+ [1- Leave] -> getStepThree

/*
    Activities
*/
=== breakfast_1 ===
# image_black
"Hello sugar cube. I hope you're starving!"
The chef hands you a tray from the pile next to him. "Enjoy your breakfast!"
+ [1- Leave.] -> foodGet

=== dinner_1 ===
# image_black
"Hello sugar cube. This time, you get to decide what to have for dinner. Please fill out the paper now."
You get a new pencil, and a questionnaire to fill out
+ [1- Fill out questionnaire.] -> foodGetAndQuestionnaire

=== breakfast_2 ===
# image_black
"Hello sugar cube. Plenty to go around!"
The chef hands you a tray from the pile next to him. "Enjoy your breakfast!"
+ [1- Leave.] -> foodGet

=== dinner_2 ===
# image_black
"Hello sugar cube. This time, you get to decide what to have for dinner. Please fill out the paper now."
You get a new pencil, and a questionnaire to fill out
+ [1- Fill out questionnaire.] -> foodGetAndQuestionnaire


// first therapist meeting
=== meeting_11 ===
# image_black
Do you want to talk to the therapist?
Time will advance by 8 hours.
+ [1- Talk to therapist.] -> meeting_1
+ [2- Don't.] -> stopNovel

=== meeting_1 ===
# therapyIncrement
You: "Do you see yellow text while closing your eyes?"
Therapist Rose: "Like… thinking of words and then imagining them in physical form? I think everyone does? What does the yellow text say by the way?"
You: "It’s says ‘You’re insane if you trust her.’"
Therapist: "Ha-ha. Nothing un-insane about a visual hallucination telling you that you're not insane."
+ [1- Continue.] -> meeting_1_2
=== meeting_1_2 ===
# sanityDownTwice
Therapist Rose: "I will let you in on a secret. There IS a step in the ritual that I know of:"
"Step Two is to have a specific meal. Apple juice and meat. That's all I'm going to say. And good luck doing that in the less than 2 days that this world has."
She shifts her legs and continues: "My real employer provides me with $2000 per hour to... humor you. There's a wagering contest going on. And it looks like you're on the losing side already."
She leaves, leaving you absolutely stunned in your seat. A while later you go back to your room to think.
+ [1- Continue.] -> setTimeFollowingTimePeriodAndKnowStepTwo

// second therapist meeting
=== meeting_22 ===
# image_black
Do you want to talk to the therapist?
Time will advance by 8 hours.
+ [1- Talk to therapist.] -> meeting_2
+ [2- Don't.] -> stopNovel

=== meeting_2 ===
# image_black
# therapyIncrement
This is a different therapist than before. She does not recognize the previous therapist. You spend the entire 1-on-1 session relaying the world ending phenomenon.
You: "... and that’s why you need to let me out. I would honestly prefer to have the world end rather than experience what’s going to happen in 2 days."
Therapist: "Fascinating… Your delusions are consistent. Usually schizophrenic people have holes in their explanations."
+ [1- "So you don’t believe me?"] -> meeting_2_2
+ [2- "So you’ll let me out?"] -> meeting_2_2
=== meeting_2_2 ===
Therapist: "No."
+ [1- Continue.] -> meeting_2_3
=== meeting_2_3 ===
At the conclusion of the therapy activity, you go back to your room.
+ [1- Leave.] -> setTimeFollowingTimePeriod

// third therapist meeting
=== meeting_33 ===
# image_black
Do you want to talk to the therapist?
Time will advance by 8 hours.
+ [1- Talk to therapist.] -> meeting_3
+ [2- Don't.] -> stopNovel

=== meeting_3 ===
# image_black
# therapyIncrement
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
=== group_11 ===
# image_black
Do you want to join this group meeting?
Time will advance by 8 hours.
+ [1- Join group.] -> group_1
+ [2- Don't.] -> stopNovel

=== group_1 ===
# image_black
# groupIncrement
# sanityUp
"Alright class! Everyone, grab a seat from the dining room and sit around in a circle."
It's a fairly standard group therapy session. Everyone introduces themselves by name and a fun fact about them. The group leader speaks like a bro - you feel like you could be friends with him outside of the hospital. There's also a "musical therapist" who plays guitar songs on demand.
It's actually pretty nice being here!
+ [1- Continue.] -> hasBrother
/*
    Redundant since brother now shows up on the first meeting everytime.
    === checkBrother ===
    # checkBrother
    -> END
*/
=== hasBrother ===
# image_black
# sanityDownTwice
At the conclusion of the group, a man bumps into you.
He says: "Step One is to call a number! It’s on your wrist!"
You look at the ID bracelet given to you on entrance to the hospital. The ID number reads: 69624-105-9226. Does this number mean anything significant?
He gets tackled by two orderlies built like bulldozers. "I’M YOUR BROTHER!" He says, as he gets dragged away and into the elevator. "I love you very much!" he says.
You don’t know who he is or where he will be taken.
"He says that to everyone," the group leader claims, smiling knowingly.
+ [1- Continue.] -> setTimeFollowingTimePeriodAndKnowStepOne

// second group meeting
=== group_22 ===
# image_black
Do you want to join this group meeting?
Time will advance by 8 hours.
+ [1- Join group.] -> group_2
+ [2- Don't.] -> stopNovel

=== group_2 ===
# groupIncrement
During the group therapy, someone mentions needing to leave the hospital early: "I have to get to work! I’ll be fired otherwise!"
The group leader responds: "Your life is more important than your welfare. We cannot trust you to go to work. We cannot even trust you to eat without supervision! You leave the hospital early by showing us signs of you getting better, getting less… "weird"."
You: "How long do people stay here at this hospital?"
"For the real basket cases? 3 months to a year. For most? As few as 3 to 5 days..."
You: "So, you’re saying I’m leaving in two days?"
"HAH. I see why they call you kooky!"
+ [1- Continue.] -> group_2_2
=== group_2_2 ===
A therapy cat named Littlepip shows up. He's the cuddliest cat ever, which is saying a lot as the cats you know do not cuddle.
+ [1- Pet the cat.] -> group_pet
+ [2- Kill the cat.] -> group_catCheckPen

// third group meeting if you dont attack cat
=== group_33 ===
# image_black
Do you want to join this group meeting?
Time will advance by 8 hours.
+ [1- Join group.] -> group_3
+ [2- Don't.] -> stopNovel

=== group_3 ===
# groupIncrement
They give everyone crayons, which you are too dull for anything but drawing.
The group leader says: "Engaging in art and crafts can be highly therapeutic. It allows you to express yourselves creatively."
"It also creates a space for you to engage with others in a collaborative way, building social skills and a sense of community."
The drawing you make looks like the work of a talented 8-year-old. As you almost throw it away, the group leader interjects: "Please don’t throw out your drawings in the trash, even if you’re not happy with them. It’s disheartening for me to see all the years I spent in art therapy training gone wasted, haha!."
+ [1- Continue.] -> group_3_2

=== group_3_2 ===
At the end of the group, the nurses bring the therapy cat Littlepip.
+ [1- Pet the cat.] -> group_pet
+ [2- Kill the cat.] -> group_catCheckPen

// attack the cat
=== group_pet ===
# sanityUp
The cat is as furry as you expect from a cat.
You go back to your room at the conclusion of this group session.
+ [1- Leave.] -> setTimeFollowingTimePeriod

=== group_catCheckPen ===
# sanityDownTwice
# catKillCheck
-> END

=== group_killcat_HasPen ===
# sfx_cryLoud
"Holy shit," half the people in the group exclaim as you stab the cat with your sharp pencil.
"You have COMPLETELY lost your mind," yells the group leader.
The orderlies usher you away as you clutch the pencil with the cat's blood on it. You hope the ritual was worth killing Littlepip cold-blooded.
+ [1- Leave.] -> setTimeFollowingTimePeriod
=== group_killcat_NoPen ===
# sfx_crySmall
You do not have a sharp tool to attack the cat. Nevertheless, you bludgeon it with your fist.
You make contact, but it's not enough to kill the cat. Littlepip hisses and runs out of the room.
"What the hell are you doing?" yells the group leader.
The orderlies usher you away. This could set back the progress of your psychiatric hold, but that doesn't matter given the world is ending.
+ [1- Leave.] -> setTimeFollowingTimePeriod

/*
    Dreams
*/

=== dream_0 === // turn to stone
# image_black
# sanityDown
You feel an unnatural weight on your limbs as an unseen force begins the petrification process. The ground beneath you, once soft and yielding, turns into an unforgiving surface that clings to your feet, making every step a struggle. The air thickens with an unsettling stillness, and an eerie silence surrounds you, broken only by the distant echoes of your own footsteps.
As you desperately try to escape, your movements become slower, more laborious. Your skin starts to take on a cold, stony texture, and a creeping numbness spreads through your body. Panic sets in as you realize that your very essence is being transformed into unfeeling stone.
+ [1- Arise.] -> wakeupToMorning

=== dream_1 === // Family replaced by clones // unused
# image_black
# sanityDown
You wake up to a world that seems eerily familiar yet unsettlingly different. As you navigate your once-familiar home, a sinister realization takes hold – your family has been replaced by emotionless, identical clones. Their faces bear an uncanny resemblance to your loved ones, but their eyes lack warmth, their voices devoid of genuine emotion.
The air is heavy with an unnatural stillness as these doppelgangers move through the house, mimicking the routines and gestures of your family members with an unsettling precision. Conversations are stilted and void of genuine connection, each interaction leaving you with a sense of profound alienation.
+ [1- Arise.] -> wakeupToMorning

/*
    Outro objects
*/
=== startOutro_1 ===
# image_black
# blueText
I arise from a bathtub filled with water and a red liquidy substance. The incantation must have worked, memory fog is a possible side-effect.
One thing my mind is telling me: What happened in the hospital was purgatory. This is the real world. The future. A voice in my head tells me that I'm about to experience my real timeline.
I hear a knock from the door. Slowly, I drag myself out all wet. I sit until I dry and gather the courage to confront whoever waits on the other side.
+ [1- Stand up] -> func_startOutro

=== func_startOutro ===
# func_startOutro
-> END

=== outro_brother_1 ===
You see that stranger again, from the group session... your brother?
He says, "come with me now." Surprisingly, he isn’t speaking English. He’s speaking a language you haven’t heard since you were six years old, yet you understand him perfectly.
"You’ve stopped the time travelers’ invasion. That was really clutch! But I doubt that you would have done that without me!"
He continues, "This corridor is tricky. Look with your heart, not your eyes. That’s how you navigate it."
+ [1- Continue.] -> stopNovel

=== outro_ending_1 ===
Your brother is standing beside you. "The ritual was a test to gauge if this time era is worth preserving. We were testing your faith, and you’ve succeeded. You have convinced the leader of the invasion to stop from possibly destroying time itself."
"Who?"
"Him."
You see a middle-aged man before you. A stern figure in a military uniform, sunglasses, and a beret. He exudes an aura of authority despite being slightly shorter than you. His gaze pierces through you as he speaks.
+ [1- Continue.] -> outro_ending_2

=== outro_ending_2 ===
Military man: "So what brings you here? Are you seeking to join our ranks? Or are you standing in my way?"
"I think I’m standing in the way."
A chilling grin twists his lips as he leans in closer "Keep this sharp attitude and I'll gouge out your eyes, shatter your fingers, and make every moment a torment. Trust me. I have the technology to ensure you suffer to no end!"
You: "I assumed from the ritual that you’re a worshiper? In that case, you must acknowledge that only your god has the authority to dispense punishment. Kill me now and let god account for my deeds."
His expression darkens, but he steps back, the threat lingering in the air like a shadow.
+ [1- Continue.] -> outro_ending_3

=== outro_ending_3 ===
You: "What was with this ritual? It didn’t make sense! The last meal?"
Military man: "People in your time are such weak, tender kids. All those ‘lab grown, imitation meats’ you have. I had to force-feed you real meat!"
"A random phone number to dial?"
Military man: "That was MY phone number, you moron! You forgot your own father’s phone number?!"
"What? So you’re my father?"
Military man: "Yes, your real father."
+ [1- Continue.] -> outro_ending_4

=== outro_ending_4 ===
You: "And the sacrifice?"
Military man: "I wanted to see if you’re willing to martyr or kill for the good of your timeline!"
"Well. I jumped through your hoops. What now?"
Military man: "To be honest. I didn’t think you had it in you to pray. I’m reconsidering what I want to do with you."
"So that’s what a paternal bond feels like?"
+ [1- Continue.] -> outro_ending_5

=== outro_ending_5 ===
Military man: "I left you because you wouldn’t behave, and it looks like that wasn’t enough punishment. I thought it was enough to send you back in time to this dark age of humanity. But now I want to run you through a meat grinder like that therapist Rose."
Your brother interjects, "let’s go back to our time and talk this through. You’re about to destroy a time period from before time traveling was invented."
The military man stares at both of you venomously. And then leaves the room to vent.
+ [1- Continue.] -> outro_ending_6

=== outro_ending_6 ===
"So what happens now?" You say to your newfound brother.
"Now, you will write the ritual paper, and we will send it back in time to complete the time loop. And then… you will come with us. Sending you back to your time period with knowledge of time travel and the invasion could jeopardize our present."
Your brother smiles at you. "Trust me, we have a lot to catch up on."
\- The end -
Thank you for playing! - Alexis Clay
+ [1- End game.] -> restartGame

=== jail_0 ===
# image_black
You feel that you are facing a pitch black jail cell.
This specific cell is empty.
+ [1- Leave.] -> stopNovel

=== jail_1 === // Elena "The Chrono Thief" Dawson
# image_black
You feel that you are facing a pitch black jail cell. A voice in your head describes who is captured in it:
Elena "The Chrono Thief" Dawson: Elena gained notoriety for her ability to steal artifacts from various time periods using advanced time-travel technology. Her crimes disrupted historical timelines and posed a threat to the stability of the space-time continuum. She was captured by the time-traveling prison operators to prevent further temporal disruptions.
+ [1- Leave.] -> stopNovel

=== jail_2 === // Dr. Samuel Reed
# image_black
You feel that you are facing a pitch black jail cell. A voice in your head describes who is captured in it:
Dr. Samuel Reed: Dr. Reed was once a brilliant physicist who became obsessed with unraveling the mysteries of time travel. In his pursuit of knowledge, he conducted dangerous experiments that endangered the fabric of reality itself. His reckless actions led to multiple temporal anomalies and paradoxes, prompting the time-traveling prison operators to apprehend him before he could cause further damage.
+ [1- Leave.] -> stopNovel

=== jail_3 === // Vincent "The Temporal Assassin" Blackwood
# image_black
You feel that you are facing a pitch black jail cell. A voice in your head describes who is captured in it:
Vincent "The Temporal Assassin" Blackwood: Vincent was a skilled assassin who specialized in eliminating targets across different points in history. His services were sought after by powerful individuals and organizations looking to alter the course of events for their own gain. However, his indiscriminate killings threatened the stability of the timeline, prompting the time-traveling prison operators to intervene and apprehend him before he could cause irreparable harm to history.
+ [1- Leave.] -> stopNovel

=== jail_4 === // Amelia "The Time-Sorceress" Hawthorne
# image_black
You feel that you are facing a pitch black jail cell. A voice in your head describes who is captured in it:
Amelia "The Time-Sorceress" Hawthorne: As a practitioner of forbidden temporal magic, Amelia wielded powers that could manipulate the very fabric of time itself. Her rituals and incantations posed a grave threat to the temporal balance, causing ripples and distortions across multiple timelines. The time-traveling prison operators deemed her too dangerous to roam freely and took her into custody to prevent her from unleashing further chaos.
+ [1- Leave.] -> stopNovel
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
# sayonaraStart_Intro
-> END

=== start3DGame === // only one tag at a time
# start3DGame
-> END

=== stopNovel === // only one tag at a time
# closeNovel
-> END

=== stopNovelTeleportPlayerToRitualRoom === // only one tag at a time
# stopNovelTeleportPlayerToRitualRoom
-> END

=== ending_bad_ritualIncorrect ===
# ending_bad_ritualIncorrect
-> END
=== ending_good_sacrificeChaplain ===
# ending_good_sacrificeChaplain
-> END
=== ending_good_sacrificePet ===
# ending_good_sacrificePet
-> END
=== ending_good_sacrificeSelf ===
# ending_good_sacrificeSelf
-> END

=== setTimeFollowingTimePeriod === // in case an event forwards the time but we're not sure if it's morning or evening.
# setTimeFollowingTimePeriod
-> END
=== setTimeFollowingTimePeriodAndKnowStepOne === // in case an event forwards the time but we're not sure if it's morning or evening.
# knowStepOne
# setTimeFollowingTimePeriod
-> END
=== setTimeFollowingTimePeriodAndKnowStepTwo === // in case an event forwards the time but we're not sure if it's morning or evening.
# knowStepTwo
# setTimeFollowingTimePeriod
-> END

=== getStepThree ===
# knowStepThree
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

=== restartGame ===
# restartGame
-> END