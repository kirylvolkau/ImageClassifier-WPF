# Image classifier in WPF
### Technologies : 
1. `customvision.ai` API by Microsoft : https://www.customvision.ai/
2. C#, WPF: 
   1. HTTPClient
   2. DataBinding
3. JSON : 
   1. `Newtonsoft.Json` NuGet package
   2. http://jsonutils.com 
4. Unsplash

### Workflow
On the main window you can select image using `OpenFileDialog` by pressing **Select** button. After that you will be by default sent to the `ai-images` folder with images of three objects : Eiffel tower, "Golden Gate" bridge and Kukulcan temple. After selecting of the images the selected image will be displayed on the main page. <br/>
The image is converted to byte array and sent to the **customvision.ai** API. There it classified and returned in the `json` format in body of the HTTP response, conatining different tags available for my prediction model and probability of the correlation of object on this image with the tag. <br/>
My prediction model was trained on Custom Vision project website using small dataset of 30 pictures, labeled by me. It allows to recognize three landmarks : Eiffel tower, "Golden Gate" bridge and Kukulcan temple with tags assigned being `eiffel`, `golden`, `kukulcan` respectively. <br/>
I used http://jsonutils.com website to generate classes from `json` response and then using `Newtonsoft.Json` NuGet package the response is deserialized into the object of corresponding class. This result is set as `ItemsSource` for the `ListView` object, displaying tags and probabilities, data binding is done for `Tag` and `Probability` property. <br/>
The result appears not immedeatly, but because of usage of custom `async` method for request sending, image to array of butes processing and response deserialization whole application doesn't stop responding.

### Screenshots
<image src="src/cvapi.png" height=300 />
<image src="src/example1.png" height=300 />
<image src="src/example2.png" height=300 />

### Notes : 
Photos in folder were taken from Unsplash, so, here are the references : 
[JOHN TOWNER](https://unsplash.com/@heytowner?utm_source=unsplash&utm_medium=referral&utm_content=creditCopyText) 
[Billy Chester](https://unsplash.com/@billychester?utm_source=unsplash&utm_medium=referral&utm_content=creditCopyText) 
[Evgeny Tchebotarev](https://unsplash.com/@ev25?utm_source=unsplash&utm_medium=referral&utm_content=creditCopyText)
[Jordi Vich Navarro](https://unsplash.com/@jvich?utm_source=unsplash&utm_medium=referral&utm_content=creditCopyText) <br/>
And two photos were taken from google images, so, here are the links in case of intellectual property questions : <br/>
[Kukulcan 1](https://pl.tripadvisor.com/Attraction_Review-g150808-d153380-Reviews-Templo_de_Kukulkan-Chichen_Itza_Yucatan_Peninsula.html) <br/>
[Kukulcan 2](https://commons.wikimedia.org/wiki/File:003_El_Castillo_o_templo_de_Kukulkan._Chichén_Itzá,_México._MPLC.jpg)
