import React from 'react'

const Stats = () => {
    return (
        <div className='flex justify-center mt-12 my-12'>
            <div className='container flex justify-center'>
                <div className='grid grid-cols-1 gap-4 md:grid-cols-3'>
                    <div>
                        <span className='text-5xl font-bold text-blue-500 leading-snug flex justify-center'>71+</span>
                        <h4 className='text-title text-xl font-bold text-center leading-snug z-50'>Sân cầu lông</h4>
                        <p className='text-center leading-7 text-base font-light tracking-tight text-description'>Với  hơn 71 sân cầu lông khắp các quận HCM</p>
                    </div>
                    <div className=''>
                        <span className='text-5xl font-bold text-blue-500 leading-snug flex justify-center'>300+</span>
                        <h4 className='text-title text-xl font-bold  text-center leading-snug'>Học viên</h4>
                        <p className='text-center  leading-7 text-base font-lighttracking-tight text-description'>Đã có trên 300 học viên đăng kí tại câu lạc bộ</p>
                    </div>
                    <div className=''>
                        <span className='text-5xl font-bold text-blue-500 leading-snug flex justify-center'>100+</span>
                        <h4 className='text-title text-xl font-bold  text-center leading-snug'>Đánh giá</h4>
                        <p className='text-center leading-7 text-base font-light tracking-tight text-description '>Hơn 100 học viên đánh giá từ khách hàng</p>
                    </div>
                </div>
            </div>
        </div>

    )
}

export default Stats