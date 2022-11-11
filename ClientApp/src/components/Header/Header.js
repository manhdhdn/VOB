import React from 'react'
import Navbar from '../Navbar/Navbar'
const Header = () => {

  return (
    <div>
      <Navbar />
      <div className="bg-[url('./assets/headerbg.jpg')] w-full h-700 bg-cover -z-10 relative ">
      </div>
      <div className='absolute top-1/3 left-32 md: ' >
        <h1 className='text-white text-4xl font-bold bg-blue-500 font m-2 line p-2 rounded ' >Enjoy badminton</h1>
        <h1 className='text-white text-4xl font-bold bg-blue-500 font m-2 p-2 rounded' >With VOB Academy</h1>
      </div>
    </div>
  )
}

export default Header