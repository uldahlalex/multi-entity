import { APITester } from "./APITester";
import "./index.css";

import logo from "./logo.svg";
import reactLogo from "./react.svg";
import {useEffect, useState} from "react";

export function App() {

    const [books, setBooks] = useState([])

    useEffect(() => {
        //call the API
        fetch('https://localhost:5000/getBooks').then(r => {

        })
    }, []);

  return (
    <div className="app">
    {/*    display books */}
        {
            books.map(b => {
                return <div>{b.Id}</div>
            })
        }

    </div>
  );
}

export default App;
