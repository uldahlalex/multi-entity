import { APITester } from "./APITester";
import "./index.css";

import logo from "./logo.svg";
import reactLogo from "./react.svg";
import {useEffect, useState} from "react";
import {Api, type Book} from "@/api/Api.ts";

export const MyApi = new Api();

export function App() {

    const [books, setBooks] = useState<Book[]>([])

    useEffect(() => {
        //call the API
        MyApi.getBooks.libraryGetBooks().then(r => {
            setBooks(r)
        })
    }, []);

  return (
    <div className="app">
    {/*    display books */}
        {
            books.map(b => {
                return <div key={b.id}>Book title: {b.title}</div>
            })
        }

    </div>
  );
}

export default App;
