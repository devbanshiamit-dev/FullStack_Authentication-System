import React from 'react';
import { useState } from 'react';
import gsap from "gsap";
import Register from './components/Register';
import Login from './components/Login';

function App() {
  const [isLogin, setIsLogin] = useState(false);

  return (
    <>
      <Register />
      <Login />
    </>
  );
};

export default App;