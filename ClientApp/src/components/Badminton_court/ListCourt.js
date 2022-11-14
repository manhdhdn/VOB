import { Container } from '@mui/material'
import React from 'react'
import Navbar from '../Navbar/Navbar';
import Box from '@mui/material/Box';
import Grid from '@mui/material/Grid';
import TextField from '@mui/material/TextField';
import Autocomplete from '@mui/material/Autocomplete';
import Slider from '@mui/material/Slider';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import { CardActionArea } from '@mui/material';
import Rating from '@mui/material/Rating';
import NearMeIcon from '@mui/icons-material/NearMe';
import SearchIcon from '@mui/icons-material/Search';
import Drawer from '@mui/material/Drawer';
import Button from '@mui/material/Button';
import FilterListIcon from '@mui/icons-material/FilterList';
const ListCourt = () => {

    //Autocomplete
    function valuetext(value) {
        return `${value}VND`;
    }
    const [value, setValue] = React.useState([0, 30]);

    const handleChange = (event, newValue) => {
        setValue(newValue);
    };
    //Drawer
    const [state, setState] = React.useState({
        left: false,

    });
    const toggleDrawer = (anchor, open) => (event) => {
        if (event.type === 'keydown' && (event.key === 'Tab' || event.key === 'Shift')) {
            return;
        }

        setState({ ...state, [anchor]: open });
    };
    const list = (anchor) => (
        <Box
            sx={{ width: anchor === 'top' || anchor === 'bottom' ? 'auto' : 350, display: { xs: 'block', md: 'none' } }}
            role="presentation"
            onClick={toggleDrawer(anchor, false)}
            onKeyDown={toggleDrawer(anchor, false)}
        >
            <h6 className='my-10'>Tìm thấy 40 kết quả</h6>
            <h6 className='mb-5'>Địa điểm</h6>
            <Autocomplete
                disablePortal
                id="combo-box-demo"
                options={top100Films}
                sx={{ width: 300 }}
                renderInput={(params) => <TextField {...params} label="Vị trí" />}
            />
            <h6 className='mb-5 mt-10'>Khoảng giá</h6>
            <div className='w-72'>
                <Slider
                    getAriaLabel={() => 'Temperature range'}
                    value={value}
                    onChange={handleChange}
                    valueLabelDisplay="auto"
                    getAriaValueText={valuetext}
                />
            </div>
        </Box>
    );

    return (
        <div>
            <Navbar />
            <Container maxWidth='xl' className='pt-32'>
                <Box sx={{ flexGrow: 1 }}>
                    <Grid container spacing={2}>
                        <Grid item md={3} lg={3} sx={{ display: { xs: 'none', md: 'block' } }} >
                            <h6 className='my-10'>Tìm thấy 40 kết quả</h6>
                            <h6 className='mb-5'>Địa điểm</h6>
                            <Autocomplete
                                disablePortal
                                id="combo-box-demo"
                                options={top100Films}
                                sx={{ width: 300 }}
                                renderInput={(params) => <TextField {...params} label="Vị trí" />}
                            />
                            <h6 className='mb-5 mt-10'>Khoảng giá</h6>
                            <div className='w-72'>
                                <Slider
                                    getAriaLabel={() => 'Temperature range'}
                                    value={value}
                                    onChange={handleChange}
                                    valueLabelDisplay="auto"
                                    getAriaValueText={valuetext}
                                />
                            </div>
                        </Grid>
                        <Grid item xs={12} sm={9} md={9} lg={9}>
                            <Box sx={{ display: { xs: 'block', md: 'none' } }}>
                                {['left'].map((anchor) => (
                                    <React.Fragment key={anchor}>
                                        <Button onClick={toggleDrawer(anchor, true)}><FilterListIcon sx={{ fontSize: 40 }} /></Button>
                                        <Drawer
                                            anchor={anchor}
                                            open={state[anchor]}
                                            onClose={toggleDrawer(anchor, false)}
                                        >
                                            {list(anchor)}
                                        </Drawer>
                                    </React.Fragment>
                                ))}
                            </Box>
                            <div className='w-full flex justify-center'>
                                <div className='md:w-1/2 flex m-5 '>
                                    <TextField className='rounded focus:outline-none' fullWidth label="Keyword" id="fullWidth" />
                                    <Button className='ml-5' variant="contained"><SearchIcon sx={{ fontSize: 40 }} /></Button>
                                </div>
                            </div>
                            <Container>
                                <Grid container spacing={7} justify="flex-start">
                                    <Grid item xs={12} sm={6} md={4} lg={4}>
                                        <Card >
                                            <CardActionArea>
                                                <CardMedia
                                                    component="img"
                                                    height="140"
                                                    image="https://wallpapercave.com/wp/wp2302343.jpg"
                                                    alt="green iguana"
                                                    sx={{ boxShadow: 15 }}
                                                    className='rounded-2xl'
                                                />
                                                <CardContent>
                                                    <Typography className='text-title' gutterBottom variant="h5" component="div">
                                                        Sân Đồng Tháp
                                                    </Typography>
                                                    <div className='flex justify-between'>
                                                        <Rating name="half-rating" defaultValue={2.5} precision={0.5} />
                                                        <Typography variant="body1" color="text.secondary">
                                                            500 rating
                                                        </Typography>
                                                    </div>
                                                    <div className='flex justify-between mt-4'>
                                                        <Typography variant="body2" color="text.secondary">
                                                            <NearMeIcon color='primary' /> Tân Phú
                                                        </Typography>
                                                        <Typography className='leading-3' variant="body2" color="text.secondary">
                                                            200.000đ/h
                                                        </Typography>
                                                        <Typography variant="body2" color="text.secondary">
                                                            500 review
                                                        </Typography>
                                                    </div>
                                                </CardContent>
                                            </CardActionArea>
                                        </Card>
                                    </Grid>
                                    <Grid item xs={12} sm={6} md={4} lg={4}>
                                        <Card >
                                            <CardActionArea>
                                                <CardMedia
                                                    component="img"
                                                    height="140"
                                                    image="https://wallpapercave.com/wp/wp2302343.jpg"
                                                    alt="green iguana"
                                                    sx={{ boxShadow: 15 }}
                                                    className='rounded-2xl'
                                                />
                                                <CardContent>
                                                    <Typography className='text-title' gutterBottom variant="h5" component="div">
                                                        Sân Đồng Tháp
                                                    </Typography>
                                                    <div className='flex justify-between'>
                                                        <Rating name="half-rating" defaultValue={2.5} precision={0.5} />
                                                        <Typography variant="body1" color="text.secondary">
                                                            500 rating
                                                        </Typography>
                                                    </div>
                                                    <div className='flex justify-between mt-4'>
                                                        <Typography variant="body2" color="text.secondary">
                                                            <NearMeIcon color='primary' /> Tân Phú
                                                        </Typography>
                                                        <Typography className='leading-3' variant="body2" color="text.secondary">
                                                            200.000đ/h
                                                        </Typography>
                                                        <Typography variant="body2" color="text.secondary">
                                                            500 review
                                                        </Typography>
                                                    </div>
                                                </CardContent>
                                            </CardActionArea>
                                        </Card>
                                    </Grid>
                                    <Grid item xs={12} sm={6} md={4} lg={4}>
                                        <Card >
                                            <CardActionArea>
                                                <CardMedia
                                                    component="img"
                                                    height="140"
                                                    image="https://wallpapercave.com/wp/wp2302343.jpg"
                                                    alt="green iguana"
                                                    sx={{ boxShadow: 15 }}
                                                    className='rounded-2xl'
                                                />
                                                <CardContent>
                                                    <Typography className='text-title' gutterBottom variant="h5" component="div">
                                                        Sân Đồng Tháp
                                                    </Typography>
                                                    <div className='flex justify-between'>
                                                        <Rating name="half-rating" defaultValue={2.5} precision={0.5} />
                                                        <Typography variant="body1" color="text.secondary">
                                                            500 rating
                                                        </Typography>
                                                    </div>
                                                    <div className='flex justify-between mt-4'>
                                                        <Typography variant="body2" color="text.secondary">
                                                            <NearMeIcon color='primary' /> Tân Phú
                                                        </Typography>
                                                        <Typography className='leading-3' variant="body2" color="text.secondary">
                                                            200.000đ/h
                                                        </Typography>
                                                        <Typography variant="body2" color="text.secondary">
                                                            500 review
                                                        </Typography>
                                                    </div>
                                                </CardContent>
                                            </CardActionArea>
                                        </Card>
                                    </Grid>
                                    <Grid item xs={12} sm={6} md={4} lg={4}>
                                        <Card >
                                            <CardActionArea>
                                                <CardMedia
                                                    component="img"
                                                    height="140"
                                                    image="https://wallpapercave.com/wp/wp2302343.jpg"
                                                    alt="green iguana"
                                                    sx={{ boxShadow: 15 }}
                                                    className='rounded-2xl'
                                                />
                                                <CardContent>
                                                    <Typography className='text-title' gutterBottom variant="h5" component="div">
                                                        Sân Đồng Tháp
                                                    </Typography>
                                                    <div className='flex justify-between'>
                                                        <Rating name="half-rating" defaultValue={2.5} precision={0.5} />
                                                        <Typography variant="body1" color="text.secondary">
                                                            500 rating
                                                        </Typography>
                                                    </div>
                                                    <div className='flex justify-between mt-4'>
                                                        <Typography variant="body2" color="text.secondary">
                                                            <NearMeIcon color='primary' /> Tân Phú
                                                        </Typography>
                                                        <Typography className='leading-3' variant="body2" color="text.secondary">
                                                            200.000đ/h
                                                        </Typography>
                                                        <Typography variant="body2" color="text.secondary">
                                                            500 review
                                                        </Typography>
                                                    </div>
                                                </CardContent>
                                            </CardActionArea>
                                        </Card>
                                    </Grid>
                                    <Grid item xs={12} sm={6} md={4} lg={4}>
                                        <Card >
                                            <CardActionArea>
                                                <CardMedia
                                                    component="img"
                                                    height="140"
                                                    image="https://wallpapercave.com/wp/wp2302343.jpg"
                                                    alt="green iguana"
                                                    sx={{ boxShadow: 15 }}
                                                    className='rounded-2xl'
                                                />
                                                <CardContent>
                                                    <Typography className='text-title' gutterBottom variant="h5" component="div">
                                                        Sân Đồng Tháp
                                                    </Typography>
                                                    <div className='flex justify-between'>
                                                        <Rating name="half-rating" defaultValue={2.5} precision={0.5} />
                                                        <Typography variant="body1" color="text.secondary">
                                                            500 rating
                                                        </Typography>
                                                    </div>
                                                    <div className='flex justify-between mt-4'>
                                                        <Typography variant="body2" color="text.secondary">
                                                            <NearMeIcon color='primary' /> Tân Phú
                                                        </Typography>
                                                        <Typography className='leading-3' variant="body2" color="text.secondary">
                                                            200.000đ/h
                                                        </Typography>
                                                        <Typography variant="body2" color="text.secondary">
                                                            500 review
                                                        </Typography>
                                                    </div>
                                                </CardContent>
                                            </CardActionArea>
                                        </Card>
                                    </Grid>
                                    <Grid item xs={12} sm={6} md={4} lg={4}>
                                        <Card >
                                            <CardActionArea>
                                                <CardMedia
                                                    component="img"
                                                    height="140"
                                                    image="https://wallpapercave.com/wp/wp2302343.jpg"
                                                    alt="green iguana"
                                                    sx={{ boxShadow: 15 }}
                                                    className='rounded-2xl'
                                                />
                                                <CardContent>
                                                    <Typography className='text-title' gutterBottom variant="h5" component="div">
                                                        Sân Đồng Tháp
                                                    </Typography>
                                                    <div className='flex justify-between'>
                                                        <Rating name="half-rating" defaultValue={2.5} precision={0.5} />
                                                        <Typography variant="body1" color="text.secondary">
                                                            500 rating
                                                        </Typography>
                                                    </div>
                                                    <div className='flex justify-between mt-4'>
                                                        <Typography variant="body2" color="text.secondary">
                                                            <NearMeIcon color='primary' /> Tân Phú
                                                        </Typography>
                                                        <Typography className='leading-3' variant="body2" color="text.secondary">
                                                            200.000đ/h
                                                        </Typography>
                                                        <Typography variant="body2" color="text.secondary">
                                                            500 review
                                                        </Typography>
                                                    </div>
                                                </CardContent>
                                            </CardActionArea>
                                        </Card>
                                    </Grid>
                                </Grid>
                            </Container>
                        </Grid>
                    </Grid>
                </Box>
            </Container>
        </div>
    )
}

export default ListCourt

const top100Films = [

    { label: 'Tân Phú ' },
    { label: 'Tân Bình', },
    { label: 'Thủ Đức', year: 1991 },
    { label: "Cảng Sài Gòn", year: 1946 },
    { label: 'Cầu Sài Gòn', year: 1997 },
    { label: 'Tân Phú ' },
    { label: 'Tân Bình', },
    { label: 'Thủ Đức', year: 1991 },
    { label: "Cảng Sài Gòn", year: 1946 },
    { label: 'Cầu Sài Gòn', year: 1997 },
    { label: 'Tân Phú ' },
    { label: 'Tân Bình', },
    { label: 'Thủ Đức', year: 1991 },
    { label: "Cảng Sài Gòn", year: 1946 },
    { label: 'Cầu Sài Gòn', year: 1997 },

];