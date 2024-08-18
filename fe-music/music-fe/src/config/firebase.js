// Import the functions you need from the SDKs you need
import { initializeApp } from "firebase/app";
import firebase from "firebase/compat/app";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
const firebaseConfig = {
  apiKey: "AIzaSyAzOLdETasav8V6zlTEj1QfjRreqOpFYaA",
  authDomain: "music-web-8e2de.firebaseapp.com",
  projectId: "music-web-8e2de",
  storageBucket: "music-web-8e2de.appspot.com",
  messagingSenderId: "479657678470",
  appId: "1:479657678470:web:bdef97e91b975d1a06e307"
};
firebase.initializeApp(firebaseConfig);
const auth= firebase.auth

export {auth}
export default firebase;