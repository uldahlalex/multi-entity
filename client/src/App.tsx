import { APITester } from "./APITester";
import "./index.css";

import logo from "./logo.svg";
import reactLogo from "./react.svg";
import {useEffect, useState} from "react";
import {Api, type Book} from "@/api/Api.ts";

export const MyApi = new Api();

export function App() {

    const [books, setBooks] = useState<Book[]>([])
    const [newBookField, setNewBookField] = useState("");

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
        <input placeholder={"enter text for new book"} value={newBookField} onChange={e => setNewBookField(e.target.value)} />
        <button onClick={() => {
            MyApi.createBook.libraryCreateBook({title: newBookField})
                .then(r => {
                    MyApi.getBooks.libraryGetBooks().then(r => {
                        setBooks(r)
                    })
            })
        }}>Click to create book</button>

    </div>
  );
}

export default App;
