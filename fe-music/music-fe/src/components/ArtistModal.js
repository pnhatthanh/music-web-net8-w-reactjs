import React from 'react'
import Scrollbars from 'react-custom-scrollbars-2'
import Modal from 'react-modal';

export default function ArtistModal({isOpen, onRequestClose, artist, thumbnail, about}) {
  return (
    <Modal
        isOpen={isOpen}
        onRequestClose={onRequestClose}
        className="w-1/3 flex flex-col justify-center items-center bg-teal-800 px-3 pb-3 relative"
        overlayClassName="fixed inset-0 bg-teal-900 bg-opacity-60 flex justify-center items-center"
    >   
        <button
            onClick={onRequestClose}
            className="absolute top-3 right-3 text-2xl text-slate-100 hover:text-white focus:outline-none"
        >
        &times;
        </button>
        <div className='flex flex-col items-center py-4'>
            <img className='h-[150px] rounded-full object-cover' src={thumbnail} alt="Artist"/>
            <h3 className='text-2xl text-slate-100 font-semibold'>{artist}</h3>
        </div>
        <Scrollbars style={{ width: '100%', height: '300px'}}>
        <div className="text-slate-200 px-3 pb-3 text-base">
            <p className='py-2'>{about}</p>
        </div>
        </Scrollbars>
    </Modal>
  )
}
