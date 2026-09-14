import "./index.css";
import {useEffect, useState} from "react";
import {Api, type Book} from "@/api/Api.ts";
import {BookComponent} from "@/BookComponent.tsx";

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
                return <BookComponent b={b} setBooks={(books) => setBooks(books)} />
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
