import React from 'react'
import Button from '@mui/material/Button';
import Modal from '@mui/material/Modal';
import TextField from '@mui/material/TextField';
import CloseIcon from '@mui/icons-material/Close';
const LoginModal = () => {

    const [open, setOpen] = React.useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);
    return (
        <div>
            <Button onClick={handleOpen} variant="outlined" size="large">Login</Button>
            <Modal
                open={open}
                onClose={handleClose}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
            >
                <div className=' absolute left-[5%] top-12 w-90 md:top-12 md:left-1/3 bg-white md:w-1/3 rounded h-600 p-10'>
                    <CloseIcon className='absolute right-0 top-0' color="primary" fontSize="large"  onClick={() => setOpen(!open)}/>
                    <div className='flex justify-center' >
                        <img
                            className="h-14 w-14 rounded-lg"
                            src="https://png.pngtree.com/png-clipart/20220823/original/pngtree-white-badminton-shuttlecock-logo-png-image_8473900.png"
                            alt="Logo"
                        />
                    </div>
                    <h1 className='text-5xl py-4 text-title'>
                        Login
                    </h1>
                    <div className='py-5'>
                        <label>Email</label>
                    </div>
                    <TextField fullWidth id="Email" />
                    <div className='py-5'>
                        <label>Password</label>
                    </div>
                    <TextField type="password" className='' fullWidth id="Email" />

                    <div className='mt-10'>
                        <Button className='w-full shadow-lg shadow-blue-500/50' variant="contained">Login</Button>
                    </div>
                </div>
            </Modal>
        </div>
    )
}

export default LoginModal