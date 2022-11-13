import React from 'react';
import Saleoffcourt from './components/Badminton_court/SaleoffCourt';
import Topbadminton from './components/Badminton_court/TopBadminton';
import Header from './components/Header/Header';

import BadmintonRacket from './components/Sportequipment/BadmintonRacket';
import Stats from './components/Stats/Stats';
function App() {
  return (
    <div className='App justify-center'>
     <Header/>
     <Stats/>
     <Topbadminton/>
     <Saleoffcourt/>
     <BadmintonRacket/>
    
    </div>

  );
}

export default App;