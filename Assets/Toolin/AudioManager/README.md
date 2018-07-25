# AudioManager

## Feature: AudioEffect (Scriptable object)
Custom audio clips can be configured.
Steps to configure:
1. Right click in the project.
2. Create/AudioEffects SO.
3. From here you set the clip size to how many Audioclips you want to play on this single object
4. Drag a Audioclip into the Inspector
5. Set the Volume and Pitch
6. Done

## Feature: Playing the Audio
Manages and play custom Audio
Steps to configure:
1. Attach to a script to the object. 
2. Add (public AudioEffectSO, audio)
3. Drag the AudioEffectSo into the inspector on the object
4. Can Call the play function from that object now 
