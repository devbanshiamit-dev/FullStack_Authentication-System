import React from 'react';
import { useRef } from "react";
import gsap from 'gsap';
import { useEffect } from 'react';

const Register = () => {


    const regCard = useRef(null);
    const logCard = useRef(null);
    const tl = useRef();


    useEffect(() => {

        gsap.set(logCard.current, {
            x: 950,
            scale: 0.9,
            opacity: 0.4
        });

        tl.current = gsap.timeline({ paused: true });

        tl.current.to(logCard.current, {
            x: 0,
            scale: 1,
            opacity: 1,
            duration: 0.8,
            ease: "power3.inOut"
        }, 0);

        tl.current.to(regCard.current, {
            x: -950,
            scale: 0.9,
            opacity: 0.4,
            duration: 0.8,
            ease: "power3.inOut"
        }, 0);

    }, []);

    function handleLogin() {
        tl.current.play();
    }

    function handleRegister() {
        tl.current.reverse();
    }

    return (
        <div>

            <div className='h-screen w-screen flex gap-5 justify-center items-center bg-gradient-to-br
            from-slate-900 via-green-900 to-emerald-800 relative overflow-hidden'>

                <div ref={regCard} className='absolute p-8 rounded-2xl flex flex-col gap-10
                    backdrop-blur-md bg-white/10 border border-white/20 shadow-2xl w-[450px] h-[520px]'>

                    <div>
                        <h1 className="text-3xl font-bold text-center text-white tracking-wide">
                            Registration
                        </h1>
                    </div>

                    <div className="flex flex-col gap-6">
                        <input
                            type="text"
                            placeholder="Enter Your Name"
                            className="w-full px-4 py-3 rounded-lg bg-white/20 border border-white/20 text-white
                         placeholder:text-white/70 outline-none focus:border-white/50 focus:bg-white/25 transition-all duration-300"/>

                        <input
                            type="email"
                            placeholder="Enter Your Emai"
                            className="w-full px-4 py-3 rounded-lg bg-white/20 border border-white/20 text-white
                         placeholder:text-white/70 outline-none focus:border-white/50 focus:bg-white/25 transition-all duration-300"/>

                        <input
                            type="password"
                            placeholder="Enter Your Password"
                            className="w-full px-4 py-3 rounded-lg bg-white/20 border border-white/20 text-white
                         placeholder:text-white/70 outline-none focus:border-white/50 focus:bg-white/25 transition-all duration-300"/>

                        <input
                            type="text"
                            placeholder="Enter Your Number"
                            className="w-full px-4 py-3 rounded-lg bg-white/20 border border-white/20 text-white
                         placeholder:text-white/70 outline-none focus:border-white/50 focus:bg-white/25 transition-all duration-300"/>
                    </div>

                    <div className="flex gap-4 justify-end">
                        <button className="bg-green-700 text-white px-5 py-2 rounded-lg hover:bg-green-800 transition-all duration-300">
                            Submit
                        </button>

                        <button className="bg-gray-200 px-5 py-2 rounded-lg hover:bg-gray-300 transition-all duration-300">
                            Clear
                        </button>
                    </div>

                    <p className="text-sm text-white text-center">
                        Already have an account?{" "}
                        <button onClick={handleLogin} className=" text-blue-300 font-semibold hover:text-white 
                                  transition-colors duration-300 cursor-pointer">
                            Sign In
                        </button>
                    </p>

                </div>

                {/* 2nd Card */}

                <div ref={logCard}
                    className="absolute p-8 rounded-2xl flex flex-col gap-10 
                    backdrop-blur-md bg-white/10 border border-white/20 shadow-2xl w-[450px] h-[400px]"
                >
                    <div>
                        <h1 className="text-3xl font-bold text-center text-white tracking-wide">
                            Log In
                        </h1>
                    </div>

                    <div className="flex flex-col gap-6 ">

                        <input
                            type="email"
                            placeholder="Enter Your Emai"
                            className="w-full px-4 py-3 rounded-lg bg-white/20 border border-white/20 text-white
                         placeholder:text-white/70 outline-none focus:border-white/50 focus:bg-white/25 transition-all duration-300"/>

                        <input
                            type="password"
                            placeholder="Enter Your Password"
                            className="w-full px-4 py-3 rounded-lg bg-white/20 border border-white/20 text-white
                         placeholder:text-white/70 outline-none focus:border-white/50 focus:bg-white/25 transition-all duration-300"/>

                    </div>

                    <div className="flex gap-4 justify-end">
                        <button className="bg-green-700 text-white px-5 py-2 rounded-lg hover:bg-green-800 transition-all duration-300">
                            Submit
                        </button>

                        <button className="bg-gray-200 px-5 py-2 rounded-lg hover:bg-gray-300 transition-all duration-300">
                            Clear
                        </button>
                    </div>

                    <p className="text-sm text-white text-center">
                        New User?{" "}
                        <button onClick={handleRegister} className=" text-blue-300 font-semibold hover:text-white 
                    transition-colors duration-300 cursor-pointer">
                            Register
                        </button>
                    </p>
                </div>
            </div>
            {/* main div */}
        </div>
    );
}
export default Register;
