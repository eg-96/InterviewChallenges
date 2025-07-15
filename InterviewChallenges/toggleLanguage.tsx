import React, { useState, createContext, useContext } from 'react';
import { createRoot } from 'react-dom/client';

const languages = ['JavaScript', 'Python'];

type LanguageContextType = {
    currentLanguage: string;
    toggleLanguage: () => void;
};

const LanguageContext = createContext<LanguageContextType>({
    currentLanguage: languages[0],
    toggleLanguage: () => {},
});

const App: React.FC = () => {
    const [currentLanguage, setCurrentLanguage] = useState(languages[0]);

    const toggleLanguage = () => {
        setCurrentLanguage((prev) => (prev === languages[0] ? languages[1] : languages[0]));
    };

    return (
        <LanguageContext.Provider value={{ currentLanguage, toggleLanguage }}>
            <MainSection />
        </LanguageContext.Provider>
    );
};

const MainSection: React.FC = () => {
    const { currentLanguage, toggleLanguage } = useContext(LanguageContext);

    return (
        <div>
            <p id="favoriteLanguage">Favorite programming language: {currentLanguage}</p>
            <button id="changeFavorite" onClick={toggleLanguage}>
                Toggle language
            </button>
        </div>
    );
};

const container = document.getElementById('root');
const root = createRoot(container!);
root.render(<App />);