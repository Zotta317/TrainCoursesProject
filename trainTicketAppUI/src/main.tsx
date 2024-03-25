import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './index.css'
import { RouterProvider, createBrowserRouter } from 'react-router-dom'
import SignIn from './components/SignIn.tsx'
import MainPage from './components/MainPage.tsx'
import Register from './components/Register.tsx'
import ProfilePage from './components/ProfilePage.tsx'


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
    element : <MainPage/>
  },
  {
    path : "/ProfilePage",
    element : <ProfilePage/>
  }
])
ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>,
)
