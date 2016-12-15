(function() {
  'use strict';

  angular
    .module('ea')
    .config(config);

  /** @ngInject */
  function config($translateProvider) {

    $translateProvider.translations('en', {

      REG:{ // Registration
        REGISTER:"Register",
        USERNAME:"Username",
        EMAIL:"Email",
        PASSWORD:"Password",
        RPASSWORD:"Confirm password", //TODO Confirm password
        REQUIRED:"Required.",
        EMAIL_NOT_WALID:"Email doesn't have valid format.",
        PASS_SHORT:"Password need to have at least 8 chars.",
        PASS_NOT_SAME:"Passwords are not same.",
        CHECK_FIELDS:"Check form fields, some of them are invalid!",
        INVALID_FORM:"Invalid form",
        MAIL_SENT:"Confirmation mail was sent to you.",
        REG_SUCCESSFUL:"Successful registration",
        USERNAME_EXISTS: "Username already exists.",
        USERNAME_REQ:"Username required.",
        USERNAME_SHORT:"Username is short. Minimal length is 6 chars.",
        EMAIL_EXISTS:"Email already exists.",
        PASS_REQ:"Password is required.",
        PASS_WEAK:"Password is weak. Password must be minimum 8 char long, and have at least one lowercase and uppercase letter.",
        REG_ERR:"Registration error.",
        LOGIN:"Log In",
        RESPASS:"Reset password",
        LOGOUTSUC:"Log out succesful.",
        SEND_RESET_CODE: "Send me a reset code",
        RESET_LINK_SENT:"Reset link sent to your email.",
        E_WRONG:"Wrong email. There is no user with this email.",
        E_REQ:"Email is required.",
        RES_REQ_FAIL:"Failed to send reset request.",
        C_PASS:"Change password",
        RH1:"Register to Euroaquaing and enjoy our services!",
        RP1:"By joining our user comunity, You will be able to order our products and easily follow the status of your order in a user-friendly environment that we provided for you!",
        RH2:"Already have an account?",
        RP21:"You can login",
        RP22:"here",
        LH:"You don't have account yet?",
        LP:"Register to Euroaquaing and enjoy our services!",
        LB:"Register here",
        PH:"Your profile",
        LOGOUT:"Log out",
        LOGIN_SUC:"Successful login",
        USER_PASS_W:"Username or password is wrong.",
        EMAIL_NOT_CONF:"Email is not confirmed.",
        BAN:"You are banned",
        LOG_FAIL:"Log in failed.",
        USERNAME_LONG:"Username is too long. Maximum length is 15.",
        EMAIL_CONF_SUC:"Email succesfully confirmed.",
        CONF_ERR:"Confirmation error",
        TOKEN_NOT_VALID:"Token is already used or not valid.",
        TOKEN_EXPIRED:"Token expired."
      },
      ORD:{ //orders
        YOURORDERS:"Your orders",
        USER:"User",
        DATETIME:"Date and time",
        STATUS:"Status",
        VALUE:"Value",
        STATS:{ //TODO look order.servise.js for ba translate
          'novi_new': 'Awaiting approval.',
          'odobren_approved': 'Approved. Waiting to send.',
          'odbijen_denied': 'Denied order.',
          'poslan_delivering': 'Order is approved and sent.'
        },
        ORD: "Order",
        DATE: "Date and time",
        ADD_INFO:"Additional info",
        ORDERED_PRODUCTS: "Ordered products",
        TOTAL:"Total",
        P1:"These actions will change order status.",
        DENY:"Deny",
        APPROVE:"Approve",
        MARK_AS_SENT:"Mark as sent",
        B_VO:"View order",
        //order.ctrl.js
        S_CHANGED:"Status changed.",
        S_CHG_ERR:"Can\'t change status, try later.",
        N_ORD_ID:"There is no order with this ID or you don't have permission."
      },
      NAV:{
        HOME:"Home",
        PRODUCTS:"Products",
        ABOUTUS:"About Us",
        CONTACTUS:"Contact Us",
        PAS:"Products and Services",
        S:{ // search
            SPAC:"Search products and categories",
            S_PLACE_H:"Type here, ex. big blu",
            NO_F:"Nothing found",
            CAT:"Categories",
            PROD:"Products",
            CANNOT_SEARCH:"Cannot search.",
            S_ERR:"Server error.",
        },
        C:{ // shoping cart
          SC:"Shopping Cart",
          NO_ITEM:"There is no items in cart",
          TOTAL:"Total",
          ADD_INFO:"Additional info",
          PLS_PHONE:"Please provide you phone number so we can contact you",
          ADD_INFO_PLACE_H:"Please write Your number or additional information here",
          PLS_LOGIN:"Please log in to continue with your order.",
          B_CANCEL:"Cancel",
          B_ORD:"Order",
          REM:"Remove",
        }
      },
      CU:{//contact us
        CU:"Contact Us",
        TOWN:"Tuzla, BiH",
        ADD:"SPO Zlokovac, Lamela A/2A, 75000 Tuzla, Bosnia and Herzegovina",
        WT:{// working time
          H:"Bussiness hours",
          P1:"Weekdays: 8:00 a.m. to 4:00 p.m",
          P2:"Saturday: 8:00 a.m. to 2:00 p.m",
          P3:"On Sundays and public holiday we are not working",
        }
      },
      H:{// home
        RM:"Read more...",
        P:{ //promo
          M1L1:"Driven by <b>passion</b>, Supported by <b>experience</b>",
          M1L2:"Chosen by <b>people</b>",
          M2L1:"We Provide Complete <b>Water Treatment</b>",
          M2L2:"Systems And Solutions"
        },
        S:{//Services
          C1H:"DESIGN",
          C1P:"We design,calculate, operate and maintain water water treatment and desalination plants.Whether your business involves water purification, desalination or custom treatment – we can provide you with innovative	and sustainable solutions.",
          C2H:"INSTALLING &amp; COMMISIONING",
          C2P:"We execute installation and commissioning activities for water treatment plants. Our experienced team have the expertise to install and commission plants.	Prior to any commissioning we create a complete technical evaluation of present situation, so that we can determine what needs to be done so that the water treatment plant	operates at projected and given capacity.",
          C3H:"CONSULTING &amp; EDUCATION",
          C3P:"Our dedicated water consultants operate across all sectors of the water industry,for all types of clients, globally. We provide your water treatment plant operators with all needed knowledge about the treatment system installed, and we provide our support and knowledge for any question you may later have.",
        },
        WA:{//water analysis
          H:"<b>WATER</b> ANALYSIS",
          P:"<div>Our expert team of engineers will find</div> " +
					"<div>An optimal solution</div> " +
				 	"<div>for your drinking water problem.</div> "
        },
        FYH:{//for you home
          H:"<b>FOR</b> YOUR <b>HOME</b>",
        },
        C:{//circles
          H1:"SAFE AND RELIABLE SERVICE",
          H2:"100% SATISFACTION GUARANTEED",
          H3:"100% SAFE SHOPPING",
        },
        IS:{// indusrial systems
          H:"<b>INDUSTRIAL</b> SYSTEMS"
        },
        SSP:{
          H:"<b>Supplies</b> and <b>spare parts</b>"
        }
      },
      A:{//Aboutus
        H:"We are an <b>innovative</b> company, very future-oriented in both our - thinking and in our actions thus incorporating these 3 rules in its daily business dealings:",
        LI1:"<b>Our Mission</b> – finding, developing and using the latest in water treatment technologies",
        LI2:"<b>Training</b> – Constant trainings of our employees ensures that the we are always informed about the latest technologies. This concept is then completed through the regular and constructive exchange of ideas between customers and us.",
        LI3:"<b>Fair Dealings</b> – with our business partners and our employees we guarantee the highest ecological and economical balance of all our systems, services and products.",
        F:"We think and work for the future. Gathering the latest technology and developments in the field of water treatment ensure that we meet this concept. Our overall concept is our flexibility. Having regular, constructive exchange of ideas between our customers and the company helps us understand their needs and that makes us a better company. For that reason we created a team of professional  experts.",
      },
      CAP:{//categories and products
        RM:"Read more...",
        ADD_TO_CART:"Add to cart",
        PRICE:"Price",
        NO_DESC:"Product doesn't have detailed description.",
        // category.ctrl
        ITEM_ADDED:"Item added to cart.",
        F_ITEM_ADDED:"Failled to add item to cart.",
        W_CAT_ID:"Wrong category ID or server error.",
      },
      ADM:{ //Admin
        P:{//panel
          ADMP:"Admin panel",
          N_ORD:"New orders",
          NO_N_ORD:"There is no new orders",
          APP_ORD:"Approved orders",
          NO_APP_ORD:"There is no new orders",
          //panel.ctrl
          C_F_ORD:"Can't fetch orders. Please try again later.",
          C_F_USER:"Can't fetch user info. Please try again later."
        }
      }
    });
    $translateProvider.translations('ba', {

      REG:{ // Registracija
        REGISTER:"Registrirajte se",
        USERNAME:"Korisničko ime",
        EMAIL:"Email",
        PASSWORD:"Lozinka",
        RPASSWORD:"Ponovite lozinku",
        REQUIRED:"Obavezno.",
        EMAIL_NOT_WALID:"Format email-a nije validan.",
        PASS_SHORT:"Lozinka mora imati najmanje 8 znakova.",
        PASS_NOT_SAME:"Lozinke nisu jednake.",
        CHECK_FIELDS:"Provjerite polja forme, neka od njih nisu ispravna!",
        INVALID_FORM:"Neispravna forma",
        MAIL_SENT:"Link za promjenu lozinke je poslan na Vaš email.", //TODO
        REG_SUCCESSFUL:"Uspješna registracija",
        USERNAME_EXISTS: "Korisničko ime već postoji.",
        USERNAME_REQ:"Korisničko ime je obavezno.",
        USERNAME_SHORT:"Korisničko ime je kratko. Najmanja dopuštena dužina je 6 znakova.",
        EMAIL_EXISTS:"Email već postoji.",
        PASS_REQ:"Lozinka je obavezna.",
        PASS_WEAK:"Lozinka je slaba. Lozinka mora bit duga bar 8 znakova i imati barem jedno veliko i jedno malo slovo.",
        REG_ERR:"Greška pri registraciji.",
        LOGIN:"Prijavite se",
        RESPASS:"Resetirajte lozinku",
        LOGOUTSUC:"Odjava uspješna.",
        SEND_RESET_CODE: "Pošaljite šifru za reset",
        RESET_LINK_SENT:"Link je poslan na Vaš mail.",
        E_WRONG:"Pogrešan email. Korisnik sa ovim email-om ne postoji.",
        E_REQ:"Polje za email je obavezno.",
        RES_REQ_FAIL:"Neuspješno slanje zahtjeva za mijenjanje lozinke.",
        C_PASS:"Promijenite lozinku.",
        RH1:"Registrujte se na Euroaquaing i koristite naše usluge!",
        RP1:"Ako se pridružite našim zadovoljnim korisnicima, moći ćete naručivati naše proizvode i lahko pratiti status Vaših narudžbi u korisnički nastrojenom okruženju koje smo omogućili za Vas!",
        RH2:"Imate postojeći račun?",
        RP21:"Možete se prijaviti",
        RP22:"ovdje",
        LH:"Nemate korisnički račun?",
        LP:"Registrirajte se na Euroaquaing i koristite naše usluge!",
        LB:"Registrirajte se ovdje",
        PH:"Vaš profil",
        LOGOUT:"Odjavite se",
        LOGIN_SUC:"Uspješna prijava",
        USER_PASS_W:"Korisničko ime ili lozinka je pogrešna.",
        EMAIL_NOT_CONF:"Email nije potvrđen.",
        BAN:"Bannovani ste",
        LOG_FAIL:"Neuspješna prijava.",
        USERNAME_LONG:"Korisničko ime predugo. Maximalna dužina je 15.",
        EMAIL_CONF_SUC:"Email uspješno potvrđen.",
        CONF_ERR:"Greška u potvrđivanju",
        TOKEN_NOT_VALID:"Token je zauzet ili nije validan.",
        TOKEN_EXPIRED:"Token je istekao."
      },
      ORD:{ //orders
        YOURORDERS:"Vaše narudžbe",
        USER:"Korisnik",
        DATETIME:"Datum i vrijeme",
        STATUS:"Status",
        VALUE:"Vrijednost",
        STATS:{ //TODO look order.servise.js for ba translate
          'novi_new': 'Čeka na odobrenje.',
          'odobren_approved': 'Odobreno. Čeka slanje.',
          'odbijen_denied': 'Odbijena narudžba.',
          'poslan_delivering': 'Narudžba je odobrena i poslana.'
        },
        ORD: "Narudžba",
        DATE: "Datum i vrijeme",
        ADD_INFO:"Dodatne informacije",
        ORDERED_PRODUCTS: "Naručeni proizvodi",
        TOTAL:"Total",
        P1:"Ove akcije će promijeniti status narudžbi.",
        DENY:"Odbij",
        APPROVE:"Odobri",
        MARK_AS_SENT:"Označi kao poslano",
        B_VO:"Pogledaj narudžbu",
        //order.ctrl.js
        S_CHANGED:"Status promijenjen.",
        S_CHG_ERR:"Nemoguće promijeniti status, pokušajte poslije.",
        N_ORD_ID:"Ne postoji narudžba s ovim id-em ili nemate odobrenje da joj pristupite."
      },
      NAV:{
        HOME:"Početna",
        PRODUCTS:"Proizvodi",
        ABOUTUS:"O nama",
        CONTACTUS:"Kontaktirajte nas",
        PAS:"Proizvodi i usluge",
        S:{ // search
            SPAC:"Pretraga proizvoda i kategorija",
            S_PLACE_H:"Ukucati ovdje, npr. big blu",
            NO_F:"Nema rezultata.",
            CAT:"Kategorije",
            PROD:"Proizvodi",
            CANNOT_SEARCH:"Pretraga onemogućena.",
            S_ERR:"Greška na serveru.",
        },
        C:{ // shoping cart
          SC:"Korpa",
          NO_ITEM:"Korpa je prazna",
          TOTAL:"Total",
          ADD_INFO:"Dodatne informacije",
          PLS_PHONE:"Molimo unesite Vaš broj telefona tako da Vas možemo kontaktirati.",
          ADD_INFO_PLACE_H:"Molimo napišite Vaš broj telefona ili dodatne informacije ovdje.",
          PLS_LOGIN:"Molimo prijavite se kako bi dovršili akciju.",
          B_CANCEL:"Otkaži",
          B_ORD:"Naruči",
          REM:"Ukloni",
        }
      },
      CU:{//contact us
        CU:"Kontaktirajte nas",
        TOWN:"Tuzla, BiH",
        ADD:"SPO Zlokovac, Lamela A/2A, 75000 Tuzla, Bosna i Hercegovina",
        WT:{// working time
          H:"Radno vrijeme",
          P1:"Radni dani: 8:00 do 4:00",
          P2:"Subota: 8:00 do 2:00",
          P3:"Nedjeljom i praznicima ne radimo.",
        }
      },
      H:{// home
        RM:"Vidi više...",
        P:{ //promo
          M1L1:"Vođeni <b>strašću</b>, Potpomognuti <b>iskustvom</b>",
          M1L2:"Izabrani od strane <b>ljudi</b>",
          M2L1:"Mi Nudimo Kompletno <b>Tretiranje vode</b>",
          M2L2:"Sisteme i Rješenja"
        },
        S:{//Services
          C1H:"DIZAJN",
          C1P:"Mi dizajniramo, računamo, operiramo i održavamo postrojenja za obradu vode i desalinizaciju. Ukoliko Vaš posao uključuje pročišćavanje vode, desalinizaciju ili specifično tretiranje – mi Vam nudimo inovativna i održiva rješenja.",
          C2H:"UVOĐENJE &amp; PUŠTANJE U RAD",
          C2P:"Mi radimo uvođenje i puštanje u rad svih naših postrojenja za tretiranje vode. Naš iskusni tim je specijalizovan za to.	Prije bilo kakvog puštanja u rad obavljamo kompletnu tehničku procjenu sadašnjeg stanja, tako da možemo odrediti šta treba biti učinjeno.",
          C3H:"SAVJETOVANJE &amp; EDUKACIJA",
          C3P:"Naši posvećeni savjetnici djeluju u svim sektorima industrije vode, za sve vrste klijenata, globalno. Mi Vam nudimo eksperte za tretiranje vode koji posjeduju i sva potrebna znanja o instalaciji sistema za pročišćavanje. Također pružamo podršku i savjete iz ove oblasti.",
        },
        WA:{//water analysis
          H:"<b>ANALIZA</b> VODE",
          P:"<div>Naš ekspertni tim inžinjera će pronaći </div> " +
					"<div>Optimalno rješenje</div> " +
				 	"<div>za Vaš problem pitke vode.</div> "
        },
        FYH:{//for you home
          H:"<b>ZA</b> VAŠ <b>DOM</b>",
        },
        C:{//circles
          H1:"SIGURNI I POUZDANI SERVISI",
          H2:"100% GARANTOVANO ZADOVOLJSTVO",
          H3:"100% SIGURNA KUPOVINA",
        },
        IS:{// indusrial systems
          H:"<b>INDUSTRIJSKI</b> SISTEMI"
        },
        SSP:{
          H:"<b>Potrošni materijal</b> i <b>rezervni dijelovi</b>"
        }
      },
      A:{//Aboutus
        H:"Mi smo <b>inovativna</b> kompanija, futuristički nastrojena u dvije stvari - razmišljanju i u našim aktivnostima, te nas vode 3 pravila u svakodnevnim poslovnim odlukama:",
        LI1:"<b>Naša Misija</b> – pronalazak, razvoj te korištenje najnovijih tehnologija u tretiranju vode",
        LI2:"<b>Treniranje</b> – Konstantni treninzi naših uposlenika osiguravaju njihovu stalnu informisanost u pogledu najnovijih tehnologija. Ovaj princip je ostvaren kroz redovne i konstruktivne razmjene ideja sa našim klijentima.",
        LI3:"<b>Fer poslovanje</b> – sa našim poslovnim partnerima i zaposlenicima garantujemo najviši ekološki i ekonomski balans svih naših sistema, servisa i proizvoda.",
        F:"Mi razmišljamo i radimo za budućnost. Obuhvatanje posljednjih tehnologija i razvoj u oblasti tretiranja vode osigurava ispunjenje ovog principa. Naš sveobuhvatni koncept je naša fleksibilnost. Redovna razmjena konstruktivnih ideja između naših kupaca i nas nam pomaže da razumijemo njihove potrebe. Zbog toga smo stvorili tim profesionalnih stručnjaka.",
      },
      CAP:{//categories and products
        RM:"Pročitajte više...",
        ADD_TO_CART:"Dodaj u korpu",
        PRICE:"Cijena",
        NO_DESC:"Proizvod nema opis.",
        // category.ctrl
        ITEM_ADDED:"Stavka dodana u korpu.",
        F_ITEM_ADDED:"Neuspješno dodavanje stavke u korpu.",
        W_CAT_ID:"Pogrešan ID kategorije ili server greška.",
      },
      ADM:{ //Admin
        P:{//panel
          ADMP:"Admin panel",
          N_ORD:"Nove narudžbe",
          NO_N_ORD:"Nema novih narudžbi",
          APP_ORD:"Odobrene narudžbe",
          NO_APP_ORD:"nema novih narudžbi",
          //panel.ctrl
          C_F_ORD:"Dobavljanje narudžbi onemogućeno. Molimo pokušajte poslije ponovo.",
          C_F_USER:"Dobavljanje informacija o korisniku onemogućeno. Molimo pokušajte poslije ponovo."
        }
      }
    });
    $translateProvider.useLocalStorage();
    $translateProvider.registerAvailableLanguageKeys(['en', 'ba'], {
      'en_*': 'en',
      'hr': 'ba',
      'sr': 'ba',
      'sh': 'ba',
      'bs': 'ba',
      '*':'en'
    })
    .determinePreferredLanguage();;
    //$translateProvider.preferredLanguage('ba');
  }

})();
