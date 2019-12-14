# shakAR
AR app to improve earth quake drill
![poster](https://github.com/WeibelLab-Teaching/CSE218_Fa19_StarX/blob/UItest/readme_pics/poster.png)

# Motivation
According to NEIC(National Earthquake Information Center, USA), there are 12,000–14,000 earthquakes each year and magnitude 2 or lighter earthquakes occur several hundred times a day worldwide. Major earthquakes(greater than magnitude 7), happen more than once per month and we all know how life threatening and devastating they can be. For instance, magnitude 7.9 earthquake struck eastern China in 2008 resulting in over 87,500 deaths, earth quake that caused the famous San Adreas fault in SF that resulted in $6B property loss in 1980s (in future it could kill and displace several thousands). Earthquakes are inevitable, all we could do is be better prepared to handle them. 

When we tested people(asked basic questions like where to hide, what places to avoid, what to do in earth quake) on earthquake survival knowledge 70% of them lacked basic knowledge and to make things worse earthquake predictions are not 100% accurate. To improve disaster preparedness of people, earthquake drill is essential. We all know how seriously people take drills :) 

To begin with we were exploring what are kind of options available to the safety and security department of any organization to hold earth quake drills. Below were our findings one some options.
1. Physical earthquake simulators- built to shake the building or physical space you are in. They are expensive and not adaptable since the room layout cannot be changed easily. 
2. Educate people using earth quake documentaries and holding evacuation drills.
3. Earthquake Simulator VR (https://www.oculus.com/experiences/rift/1708834312528485/?locale=en_US)
4. AI-Based VR Earthquake Simulator (https://link.springer.com/chapter/10.1007/978-3-319-91584-5_17)

Some of these methods aren't immersive enough and not interactive. Hence it is ineffective way of learning and lead to waste of time and human resources. VR and AI solutions are immersive but people cannot interact with reality making them less aware of the safe/danger spaces around them. 

With all this in perspective we wanted to make drills engaging, make people aware of their surroundings, enable designing cost effective immersive drill simulation. This gave us a strong motivation to build shakAR.

We used agile methodology for software development and developed MVP version of shakAR in 8weeks.

# Design: Idea
Our mantra was to
1. Build intuitive, interactive and cost effective AR app for earthquake drills.
2. Enable efficient, per user evaluation on the drills.
3. Use Double Diamond design process (Discover, Define, Develop, Deliver) and keep refining the app.

Below diagram shows the state diagram of our app. 
![StateDiagram](https://github.com/WeibelLab-Teaching/CSE218_Fa19_StarX/blob/UItest/stateDiagram.png)

1. First we scan the room to do camera calibration. This is the most important and essential step in our project, accuracy of this step how we place decides how effective the virutal objects and mark the safe/danger places we placed in the scene are.
2. Show initial help info and video explaining what is the goal of the drill.
3. User selects what level(low, medium and high) of drill he wants to take part in.
4. Drill starts. Any time during the drill user can stop/pause the drill. There is a timer showing progress of the drill.
5. At the end of the drill there is earth quake information video played along with user's performance in the drill is displayed.

# Design: Sneak Peak
### Design Icons used<br>
![Design elements](https://github.com/WeibelLab-Teaching/CSE218_Fa19_StarX/blob/UItest/readme_pics/design_icon.png)

### Drill controls <br>
![Drill controls](https://github.com/WeibelLab-Teaching/CSE218_Fa19_StarX/blob/UItest/readme_pics/drillControls.png)

### Drill rules <br>
![Drill Rules](https://github.com/WeibelLab-Teaching/CSE218_Fa19_StarX/blob/UItest/readme_pics/drillRules.png)

### Level Selection <br>
![Level selection](https://github.com/WeibelLab-Teaching/CSE218_Fa19_StarX/blob/UItest/readme_pics/levelSelection.png)

### Time bar that follows the user <br>
![Main Bar](https://github.com/WeibelLab-Teaching/CSE218_Fa19_StarX/blob/UItest/readme_pics/mainBar.png)

### Basic virtual scene that is augmented to the scene at rest <br>
![Virual Scene](https://github.com/WeibelLab-Teaching/CSE218_Fa19_StarX/blob/UItest/readme_pics/virtualScene_Aug.png)

<!--# Design: Evolvement and Final Design
Used PrototipAR to create the initial prototype of shakAR. Did user interviews(convenience sampling)  to understand how they interact with the UI. 

week 5
Refined and defined the final application logic and laid out development roadmap. 

week 6
Defined and designed basic UI/UX objects and their physics in the virtual environment, including safe zones, danger signs, warning signs and escaping routes.
Font selection :)

week 7
Integrated various UI/UX modules. Scan, Level selection, timer objects,  help info and summary.


week 8
Integrate UI/UX module with the scanning module(model of the room). Did user study, based on the feedback refined the drill logic and UI (added more signifiers and feedback)

week 9
Upscaled the warning signs and added spatial sound feedback. Added visual effects to objects to make the experience more realistic.
Added Localization and camera calibration.

Final Design
shakAR aims to provide realistic AR earthquake drills using spatial understanding and sounds, provides timely instructions and feedbacks, and finally enables user evaluation in the drill. 
-->

# System Development: Architecture
# System Development: Technology
### Device
HoloLens Version 1

### Platform
Unity 2018.4.12f1

### Development Tools
Microsoft Mixed Reality Toolkit
Microsoft Azure Cloud Services
Apple Developer Tools

# System Development: Features
### Spatial surrounding area detection 
First scan the room to build spatial mapping, providing simulation in coherence with physics and escape instructions.

### Seismic activity level selection
Prompt several seismic activity levels to users, ranging from light to heavy. Users can select any level based on their training goals.

### Spatial sounds & shaking view simulation
Spatial sounds and shaking objects simulation can provide vivid experience for users.

### Appropriate instructions and contextual feedbacks
Show appropriate escaping instructions, including safe places to hide, dangerous places to avoid and several escape routes; also provide feedback once users take actions. 

# Alpha System Development: Video

[![Alpha system video](https://github.com/WeibelLab-Teaching/CSE218_Fa19_StarX/blob/UItest/readme_pics/demo_video.png)](https://www.youtube.com/watch?v=9RqWIj9qQ9w&feature=emb_title)

# Testing and Evaluation
### UI and Usability Testing:
Throughout the quarter we conducted user testing (with friends and family).
Based on the feedback, we simplified drill logic and added more feedback mechanism in the drill. We also improvized the scene by adding more virtual objects and added dynamic scene development based on the level selected. 
As we test on more people we are gathering more data and evaluating which feedback to incorporate into shakAR.

### Evaluation:
Overall, users get quick hang of the application and correctly follow the workflow. 
shakAR achieves goals of being:
Intuitive (100% of the people didn’t have any trouble navigating through the app)
Effective learning (75% of the people completed the task within given time) 
Timely interactions (100% of the people collected all safe/danger places)

### Overall Testing:
After integrating the UI with the scanning module, the system responds pretty well except for the lag in  synchronization (suspecting network to be the issue) that crops up once in a while.

# Future work:
1. Mode selection - Provide two modes game and drill mode.
2. Support multi-players game/drill mode - Allows more than one user to participate in the earthquake drills in the same scene simultaneously.
3. Add user accounts to track user history of drills.
