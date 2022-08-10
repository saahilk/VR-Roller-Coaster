# VR-Theme-Park

This is a Virtual Reality theme park application allowing users to go on rides such as roller coaster and ferris wheel as well as interact with various 3-D objects using either a bluetooth controller or gaze based control. There are 2 modes in the app - first person and third person. User can switch between the modes by pressing a button on the controller. The app also contains 2 script generated 3-D objects - the UFO and star. 

The roller coaster follows the laws of physics to a certain extent:
- It accelerates when going downhill
- Decelerates faster when going uphill and slower on flat stretches

The roller coaster track is constructed using the track object found here : https://www.turbosquid.com/3d-models/free-3ds-model-tracks-street/727474 . I have used a free Unity package from the asset store called SplineMesh: https://assetstore.unity.com/packages/tools/modeling/splinemesh-104989 . This tool lets you create a 3-d spline using bezier curves and generates a 3-d mesh along the spline by repeating the mesh that you provide. You can then provide the material to render the mesh with. 

For pictures and additional details please check out report.pdf.

The entire project including the demo can be found at https://drive.google.com/drive/folders/1XE97y0LTd4MyZlnWcVE3aD3UBwYLM5DM?usp=sharing
