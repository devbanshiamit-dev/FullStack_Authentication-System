import React from 'react';

const Login = () => {
    return (
        <div>
            <div className="
h-screen
w-screen
flex
flex-col
gap-5
justify-center
items-center
bg-gradient-to-br
from-slate-900
via-green-900
to-emerald-800
">

                <div
                    className="
  w-full
  max-w-md
  p-8
  rounded-2xl
  flex flex-col
  gap-10
  backdrop-blur-md
  bg-white/10
  border
  border-white/20
  shadow-2xl
  "
                >

                    <div>
                        <h1 className="
text-3xl
font-bold
text-center
text-white
tracking-wide
">
                            Log In
                        </h1>
                    </div>


                    <div className="flex flex-col gap-6">
                        

                        <input
                            type="email"
                            placeholder="Enter Your Email"
                            className="
w-full
px-4
py-3
rounded-lg
bg-white/20
border
border-white/20
text-white
placeholder:text-white/70
outline-none
focus:border-white/50
focus:bg-white/25
transition-all
duration-300
"
                        />

                        <input
                            type="password"
                            placeholder="Enter Your Password"
                            className="
w-full
px-4
py-3
rounded-lg
bg-white/20
border
border-white/20
text-white
placeholder:text-white/70
outline-none
focus:border-white/50
focus:bg-white/25
transition-all
duration-300
"
                        />

                    </div>

                    <div className="flex gap-4 justify-end">
                        <button className="bg-green-700 text-white px-5 py-2 rounded-lg hover:bg-green-800 transition-all duration-300">
                            Submit
                        </button>

                        <button className="bg-gray-200 px-5 py-2 rounded-lg hover:bg-gray-300 transition-all duration-300">
                            Clear
                        </button>
                    </div>
                </div>
                <p className="text-sm text-white text-center">
                    New User?{" "}
                    <button
                        className="
      text-blue-300
      font-semibold
      hover:text-white
      transition-colors
      duration-300
      cursor-pointer
    "
                    >
                        Register
                    </button>
                </p>
            </div>
        </div>
    );
}

export default Login;