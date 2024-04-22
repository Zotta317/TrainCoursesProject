import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './index.css'
import { RouterProvider, createBrowserRouter } from 'react-router-dom'
import MainPage from './components/MainPage.tsx'
import Register from './components/RegisterPage/Register.tsx'
import ProfilePage from './components/ProfilePage.tsx'
import CoursesPage from './components/CoursesPage.tsx'
import SignIn from './components/SignInPage/SignInSide.tsx'
import HomePage from './components/MainPage/HomePage.tsx'



const router = createBrowserRouter([
  {
    path: "/",
    element: <App/>
  },
  {
    path : "/signIn",
    element : <SignIn/>
  },
  {
    path : "/register",
    element : <Register/>
  },
  {
    path :"/mainPage",
    element : <HomePage/>
  },
  {
    path : "/ProfilePage",
    element : <ProfilePage/>
  },{
    path : "CoursesPage",
    element : <CoursesPage/>
  }
])
ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>,
)
