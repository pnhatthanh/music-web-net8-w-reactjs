import React, { useEffect } from 'react'
import { useState } from 'react';

export default function Carousel() {
    const [slide, setSlide] = useState(0);

    const data=[
      "https://avatar-ex-swe.nixcdn.com/slideshow/2024/07/10/6/0/c/6/1720622014553_org.jpg",
      // "https://hoanghamobile.com/tin-tuc/wp-content/uploads/2024/04/anh-con-cho-1.jpg",
      // "https://hoanghamobile.com/tin-tuc/wp-content/uploads/2024/04/anh-con-cho-8.jpg",
    ]
    useEffect(()=>{
      const intervalId=setInterval(()=>{
        setSlide(prev=>prev==2 ? 0 : prev+1)
      },3000)
      return ()=>{
        intervalId && clearInterval(intervalId);
      }
    },[])
    return (
      <div className="w-full justify-center items-center h-[200px] relative">
        {data.map((item, idx) => {
          return (
            <img
              src={item}
              alt={idx}
              key={idx}
              className="rounded-xl w-full h-full object-cover  duration-700 ease-in-out"
            />
          );
        })}
      </div>
    )
}
