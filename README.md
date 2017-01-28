# netSlug

 - todo:
  - basic player movement
  - camera stays between levels
  - "town" level
  - secondary "instance" level; level transitions
  - firebase multi-character sync:
   - name, t, hp, x, y, dx, dy, mgun ammo, grenades, score
  - destructable background element 
  - basic walking enemy
   - enemy explodes into confetti
   - coin drops
  - basic gun
  - shop vendor
   - machine gun
   - grenade
   - tank

Current Features:
 Multiple tile-based 2d levels
 Animated 2d character
 Simple enemies
 Powerup drops
 Multiple weapons
 Simple shop vendor example
 Tank mount
 Network synchronization of multiple players
  
Project Layout:
 *Art - all visual assets
 *Audio - all audio assets
 *Data - game configuration data (where to customize weapons & characters)
  (Note: one of the reason to seperate this data from the unity prefabs, is to allow for game patches.  The engine as is isn't ready for that, but unity is designed to allow for assets like these to be downloaded without an end-user having to re-download the whole game.  As such, its a good habit to put tuning data in lightweight asset packages like this.  If you create more config files, they will all be loaded and merged by the game.  This way you can create a data package that is the base game, and one for expansion packs, etc.)
  There should be slots to add sound and music to the weapons and levels in here if you like, I don't have any appropriate tracks lying around at present.
 *Prefab
  *Actor   - the unity objects used for players/enemies/pickups
  *Blocks  - background assets used for the level construction
   (Note: if you set edit->snapSettings to use .64 as x&y units, duplicating these blocks in levels with Ctrl-D, and then dragging while holding Ctrl is the easiest way I found to build levels)
  *Effects - @TODO
  *Pads    - Objects utilized for level transitions/saving 
   (Note: you could make these invisible, or make them look like doors in the background, etc. if you prefer, I'm not implying that your game need have actual "pads" for spawning or teleporting)
  *Projectiles - Weapon projectile presentation data - bear in mind that projectile functionality is in Data
 Scenes
  Region
 Scripts - all the game engineering code
  AlexisFoundation - the base engine I bring with me in game jams, modified from the version used in CrowdWave
   ...
  NetSlug
 
General Statement:
 This is meant to be an example prototype of what might grow into a metal slug MMO concept.  I though it might be valuable to you because I know how frustrating it can be not knowing how to take an idea and create something functional out of it.  I had fun making it, but probably won't do much more on my own unless the mood strikes me.  To work on a project like this full time my rates are $80 and hour - and I know you can't afford that right now, I just wanted to mention to give you perspective on what industry game engineers with my level of experience cost.  Hopefully this can serve as a playground/example to demonstrate the types of design challenges/affordances in a game of this style.  I've also included the confetti effect you made, so that you can have an in-context example of how to embed movies into Unity.  Bear in mind that movies don't seem to work in web deployment, so relying on that feature would restrict you to downloadable executable games rather than browser games (which is a fine choice, but is harder to get people to actually play in my experience).  
 
 Please feel free to do anything you want with this.  Extend it, sell it, ignore it.
 
Alexis Foundation:
 The Code is split into two groups, the Alexis Foundation, and NetSlug.  The Foundation is a small Unity3d library I've built that I use on most code projects.  Consider it CC liscence (i.e. do whatever you like with it), and bear in mind that it's something I've hacked together to speed up game jams, not something I'd advocate for on a professional game team.  There are definitely bugs left inside it.
   
Polish Work:
 Obviously the game lacks proper art.  I'm not much of an artist and i felt it would be better to wireframe the game and let you take care of that.  Additionally, it would probably help to create better colliders to have slopes rather than treating the whole world as squares.  I've given the chracter two frames of animation, in order to illustrate a way to do animation as a starting point.  This is neither the only, nor the best way to animate a character - just the quickest way for me to get off the ground
  
Percieved Game Design Challenges:
 As an opening note, if you disagree with anything I say here, please prove me wrong and tell me how you did it.  I would much rather learn something new than be right.

 MMO's are notorious for content-creep.  Setting out to design the art for 1 characer and 1 level can be a decently time consuming polish task in itself, but to make something like this scale and maintain a following, there's an expectaition of new areas, new classes, new items, and character customization options with visual representations. That means a ton of art, and a ton of animation.  As such it might be a good idea to target a simple style with a low frame count that you (or your team) can replicate quickly, rather than setting a high standard and precedent with your first character that translates to a week-long cycle for each new addition.

 Engineering wise, expanding the network support is a big issue.  The free firebase account I've set this up with should be enough to "prove the concept" with a small group of players, but probably won't extend past a handful of users without hitting a major lag or stability wall.  Additionally, since all network logic is in the game, rather than on a dedicated server, this game as it currently is build will be trivially easy to hack.

 Unfortunately I can't really think of a proper method for doing large scale MMO networking that is both easy to understand as a code newcomer, and that doesn't cost a ton.  Even were the game completely finished, running MMO servers that can support gigabytes of art content and thousands+ users isn't cheap, and to do it for any length of time you either need to settle for substandard infrastructure, be rich, or find some way to get your players (or perhaps ads) to pay you, and doing that means adding monetization infrastructure and being prepared for legal concerns.  That's one of the reasons why even though some developers could technically make an MMO on their own, most don't.  I might even have the technical chops myself, but I've never really attempted server work on that level.  If you really do want to pursue this idea to scale, I'd reccomend you make a solid game with at least 10 hours of content that plays well with 2-4 players, make a really slick demo video, then run a kickstarter to properly hire a distributed systems engineer to scale out the infrastructure (they generally cost more than I do).  You might also be able to find a motivated engineering student to compliment your art skillset, but I've been down that path, and a warning: MMO's in particular need a really, really solid networking foundation to be playable/stable, and if there is any part of a project like this to sink money into, that's the part most important to get right.
 
 On the design side, one of the large challenges I see taking this game forward is that the Metal Slug series is primarily a scripted single player experience, and most of the level design / combat design is built around that.  
 
 In a massive multiplayer environment, you're going to have to find a way to rebalance the gameplay so that players can drop into roles and form useful and functional teams, and have those roles and teams read effectively in a 2d user experience.  The heavy machine gun/rocket launcher for example, are very loud/dramatic screen-filling weapons that would be rather overwhelming in a crowd of 12 active combatants in close quarters.  In many MMOs player progression is a large hook for retention, and figuring out how to build a suitably engaging system or system analog out of the metal slug arcade mechanics strikes me as a challenge too.  Bear in mind that a traditional leveling system is not the only way to approach this.  Most game progression systems are largely vestigal remnants of D&D and similar systems naively translated to a digital context - and there are plenty of other open ended ways to slowly introduce characters to new dynamics, complexity, and character power tiers.
 
 Similarly, designing zones and instances that make sense to explore in a non-linear fashion is going to differ significantly from the metal slug series level design.  For example, having more reasonable places for characters to stand in combat corridors rather than just charging at the front line, and being careful to arrange the destructable background elements so as to create interesting multi-character bottlenecks.
 
 Currently I've designed this game to neither be explicitly PVE or PVP.  in the non-town area there are enemies, and you can also attack each other.  I'd expect a lot of design and eng work in establishing multiple factions and getting their towns/surrounding areas to feel right, as well as figuring out how to direct players into PVP areas and keeping them balanced even if your factions themselves aren't.  A design distinction many MMOs make is to specify dedicated PVP arenas and PVE instance zones (which tend to be "owned" by a specific character or clan), but like a traditional leveling system, this is not the only way to approach the problem.  Think outside the box, please prove me wrong, please prove the industry wrong, build a community, see what your player base likes/dislikes, find a way to split your time between your vision and their complaints, and try to reconcile your ideas with their wants.