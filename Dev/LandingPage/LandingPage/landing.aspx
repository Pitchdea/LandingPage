﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="landing.aspx.cs" Inherits="LandingPage.Landing" %>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8">
        <title>Pitchdea - where ideas evolve!</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0">

        <!-- One CSS file that rules them all -->
        <link href="css/main.css" rel="stylesheet">

        <link rel="shortcut icon" href="images/favicon.ico">

        <!-- HTML5 shim, for IE6-8 support of HTML5 elements. All other JS at the end of file. -->
        <!--[if lt IE 9]>
          <script src="js/html5shiv.js"></script>
        <![endif]-->
    </head>
  
    
    <!-- Scrollspy set in the body -->
    <body id="home" data-spy="scroll" data-target=".main-nav" data-offset="73">

    <!--///////////////////////////////////////// PARALLAX BACKGROUND ////////////////////////////////////////-->

    <!-- image is set in the CSS as a background image -->
    <div id="parallax"></div>

    <!--///////////////////////////////////////// end PARALLAX BACKGROUND ////////////////////////////////////////-->


    
    <!--/////////////////////////////////////// NAVIGATION BAR ////////////////////////////////////////-->

    <section id="header">

        <nav class="navbar navbar-fixed-top" role="navigation">

            <div class="navbar-inner">
                <div class="container">

                    <button type="button" class="btn btn-navbar" data-toggle="collapse" data-target="#navigation"></button>

                    <!-- Logo goes here - replace the image with your -->
                    <a href="#home" class="navbar-brand">PITCHDEA</a>


                    <div class="collapse navbar-collapse main-nav" id="navigation">


                        <ul class="nav pull-right">

                            <!-- Menu items go here -->
                            <li class="active"><a href="#home">Home</a></li>
                            <li><a href="#info">Customers</a></li>
                            <li><a href="#business">Businesses</a></li>
                            <li><a href="#team">Team</a></li>                            
                            <li><a href="#faq">Contact</a></li>
                            <li><a href="#newsletter">Subscribe</a></li>                  
                            
                            
        
                            <!-- If you want sub-menu items, do them like this
                            <li>
                                <ul>
                                  <li><a href="#">Item 1</a></li>
                                  <li><a href="#">Item 2</a></li>
                                </ul>
                            </li> 
                            You just need to delete these comment lines -->
                        </ul>

                    </div><!-- /nav-collapse -->
                </div><!-- /container -->
            </div><!-- /navbar-inner -->
        </nav>

    </section>

    <!--//////////////////////////////////////// end NAVIGATION BAR ////////////////////////////////////////-->

    

    <!--/////////////////////////////////////// HERO SECTION ////////////////////////////////////////-->

    <section style="background:rgb(236, 240, 241);" id="hero">

        <div class="container">
            <div class="row">

                <div class="col-sm-8 intro">
                    <h2 style="color:#c0392b">PITCHDEA</h2>
                    <h3><small style="color:gray;">- where ideas evolve!</small></h3>
                    <p class="lead">We have an idea</p>
                    <p>About ideas that can change the world.</p>
                    <p>Pitchdea is a Finnish startup that aims to bring the ideas of the world together in a way never seen before. We are about crowdsourcing, creative thinking, and most of all, about ideas that can change the world.</p>
                    <p>We are eagerly pursuing our goal of creating a platform where people and ideas would collide and create something brilliant. To do this we need you, so subscribe and follow the progress of Pitchdea. You have the possibility to get a sneak peak on the upcoming website and be part of a passionate community.</p>
                    <a href="#newsletter" class="btn btn-hg btn-primary">Subscribe for news about pitchdea</a>                    
                </div>
                <div class="col-sm-4 intro social">
                  <p class="lead">Find us!</p>
                  <a class="fui-facebook large inline" href="#"></a>
                  <a class="fui-twitter large inline" href="#"></a>
                  <a class="fui-googleplus large inline" href="#"></a>
                  <a class="fui-linkedin large inline" href="#"></a>                  
                </div>

            </div><!-- /row -->
        </div><!-- /container -->

    </section>

    <!--///////////////////////////////////////////////// end HERO SECTION ////////////////////////////////////////-->

    <!--/////////////////////////////////////// INFO SECTION ////////////////////////////////////////-->

    <section id="info">

        <!--/////////// Info section alternates with white and gray backgrounds. Let's start with a white! //////////-->
        <div class="info-section-white">

            <div class="container">
                <div class="row">

                    <div class="col-md-6 pull-right gallery-popup">
                        <img src="images/forpeople.png" alt="placeholder image" class="img-responsive">
                    </div> 

                    <div class="col-md-6 pull-left">
                        <h3>Pitchdea is for People!</h3>

                        <p> Pitchdea offers a new way of sharing and discovering ideas and projects.</p>

                        <p> Ever had an idea you would have wished came real?</p>
                        <p> Find the people and evolve the idea through discussion. The end product can be anything imaginable, a comic, a tattooed leather jacket or a way for your local cafeteria to improve their service. Pitchdea aims to provide you with a way of finding out if people want the idea to come alive through our liking mechanism. But don't stop there, find similar ideas and connect with people with the means to make your idea reality. </p>
                        <p> Already read the news, blogs and seen enough cat pictures for the day?</p>
                        <p> We might just have the cure for you. Our team wants to find you interesting ideas to read while making browsing through them fun. Who knows, maybe you will find an idea you are so passionate about you will start spending your time further developing it.
                            In a nutshell we offer an interest based social media platform for creating and evolving ideas. We allow the user to share and discover ideas they are passionate about and then make them better. Join us and find the most interesting ideas and maybe some new friends! </p>
                    </div> 

                </div><!-- /row -->
            </div><!-- /container -->

        </div><!-- /info-section-white -->
       	</section>
   		<section id="business">      
        <!--/////////// And here's the gray background section! //////////-->
        <div class="info-section-gray">

            <div class="container">
                <div class="row">                   

                     <div class="col-md-6 pull-right">
                        <h3>Pitchdea is for Businesses!</h3>

                        <p>Pitchdea offers many opportunities for businesses starting but not limited to interacting with potential customers. Below we will let you know how to do just that.</p>
                        <p>New collection of shoes coming up? Wanting to test a new recipe for your cinnamon rolls but afraid it might now be taken in so well? Interested in finding new customer segments?</p>
                        <p>Through us your business can establish a solid marketing channel, access interesting demographic data, and a way to launch and validate new product lines. Best of all, this can be done with low cost from fresh data. Just for you.</p>
                        <p>What we really have here, is a way for your business to find out for example that 120 local people between the ages of 55-65 would be interested in your product. A customer segment you might not have realized existed. </p>  
                        <p>Or that 20 000 people would want to try out your intended new line of batman underwear if you would manufacture them. How it works with us is that your company can propose and idea or the customers can propose one for you themselves. Contact us and we will tell you more.</p>
                     </div>

                    <div class="col-md-6 pull-left gallery-popup">
                        <a href="http://www.placehold.it/640x480"><img src="images/forbusiness.png" alt="placeholder image" class="img-responsive"></a>
                    </div>  

                </div><!-- /row -->
            </div><!-- /container -->

        </div><!-- /info-section-white -->        
        
    </section>

    <!--/////////////////////////////////////// end INFO SECTION ////////////////////////////////////////-->

    <!--/////////////////////////////////////// FEATURES SECTION ////////////////////////////////////////-->

    <section id="team">

        <div class="container">

            <header>
                <h1>Meet Our Team</h1>
                <p class="lead">We are ready. We believe in what we do.</p>
            </header>

            <div class="row">
                
                <!-- Feature Item 1 -->
                <div class="col-md-3 text-center">
                    <div class="feature-icon">
                        <a href="http://fi.linkedin.com/in/barunbashyal" target="_blank"><img src="images/barun.png" alt="barun" class="img-circle"></a>
                    </div>
                    <h4>Barun Bashyal</h4>
                    <p>Front-End Developer</p>
                    <p>Barun is the optimist and the leader in our team. His attitude in life will shine as a bright beacon for many and his cookings will keep us satisfied.  </p>
                </div>

                <!-- Feature Item 2 -->
                <div class="col-md-3 text-center">
                    <div class="feature-icon">
                        <a href="http://www.linkedin.com/pub/kerkko-heiskanen/48/bb0/765" target="_blank"><img src="images/Kerkko.png" alt="kerkko" class="img-circle"></a>
                    </div>
                    <h4>Kerkko Heiskanen</h4>
                     <p>Front-End Developer</p>
                    <p>Kerkko is the crazy one. We live by his wild ideas and the passion in his eyes. Besides that Kerkko acts as the ultimate web guru our whole team relies on. </p>
                </div>

                <!-- Feature Item 3 -->
                <div class="col-md-3 text-center">
                    <div class="feature-icon">
                        <a href="http://www.linkedin.com/pub/tero-urponen/54/481/ab7" target="_blank"><img src="images/Tero.png" alt="tero" class="img-circle"></a>
                    </div>
                    <h4>Tero Urponen</h4>
                     <p>Lead Back-End Developer</p>
                    <p>Tero is the superman whose shoulders we are building this project on. With his knowledge in agile development and mentality of never giving up we can do anything. </p>
                </div>

                <!-- Feature Item 3 -->
                <div class="col-md-3 text-center">
                    <div class="feature-icon">
                        <a href="http://www.linkedin.com/in/tapiolouhi" target="_blank"><img src="images/Tapio.png" alt="tapio" class="img-circle"></a>
                    </div>
                    <h4>Tapio Louhi</h4>
                    <p>Back-End Developer</p>
                    <p>In Tapio’s hands the pieces of our puzzle have started to find their places. With his perspective and keen eye on information security we see the road ahead of us clearly.</p>
                </div>

            </div><!-- /row -->
        </div><!-- /container -->

    </section>

    <!--/////////////////////////////////////// end FEATURES SECTION ////////////////////////////////////////-->

    <!--/////////////////////////////////////// FAQ SECTION ////////////////////////////////////////-->

 <section style="background:rgb(236, 240, 241);" class="info-section-gray"id="faq">

        <div class="container">

            <header>
                <h1>Contact us</h1>
                <p class="lead">Do you have a question? Someone else might have had the exact same one. Let's find out!</p>
            </header>

            <div class="row">

              <div class="col-md-6">

                <!--////////// Accordion Toggle //////////-->

              

              <div class="alert">
                        
                <p class="lead">Our Contact Details</p>
                <div class="row">
                     
                  <div class="col-md-4 col-xs-6 text-left">
                    <strong>Email</strong>
                  </div>
                          
                  <div class="col-md-8 col-xs-6">
                    <address>
                      pitchdea(at)gmail.com<br>
                    </address>
                  </div>

                </div><!-- /row -->

                <div class="row">
                          
                  <div class="col-md-4 col-xs-6 text-left">
                    <strong>Skype</strong>
                  </div>
                          
                  <div class="col-md-8 col-xs-6">
                    <address>
                      pitchdea<br>
                    </address>
                  </div>

                </div><!-- /row -->

                <div class="row">
                        
                  <div class="col-md-4 col-xs-6 text-left">
                    <strong>Google+</strong>
                  </div>
                     
                  <div class="col-md-8 col-xs-6">
                    <address>
                      pitchdea<br>
                    </address>
                  </div>

                </div><!-- /row -->
                
                  <div class="row">
                        
                  <div class="col-md-4 col-xs-6 text-left">
                    <strong>Facebook</strong>
                  </div>
                     
                  <div class="col-md-8 col-xs-6">
                    <address>
                      pitchdea<br>
                    </address>
                  </div>

                </div><!-- /row -->

              </div><!-- /alert -->
            </div><!-- /col-md-6 -->

              <div style="background:white; padding-top:3px;" class="col-md-6">

                    <div class="row contact-intro">
                        <div class="col-md-3 text-right"><img src="images/icons/support.svg" alt="" /></div>
                        <div class="col-md-9"><p class="lead">Didn't find what you were looking for? Shoot us a line!</p></div>                        
                    </div>

                    <!--////////// CONTACT FORM //////////-->
                    <form id="contact-form">
                        <input type="text" id="name" name="name" class="form-control input-hg" placeholder="Your name..." />
                        <input type="text" id="email" name="email" class="form-control input-hg" placeholder="Your e-mail address..." />
                        <textarea class="form-control input-hg" rows="4" id="message" name="message" placeholder="Your message..."></textarea>
                        <button type="submit" class="btn btn-inverse btn-hg btn-block" name="submit">Send</button>
                    </form>

                     <div id="contact-error"></div>
                    <!--////////// end CONTACT FORM ///////////-->

              </div><!-- /col-md-6-->

            </div>
        </div>

    </section>

    <!--/////////////////////////////////////// end FAQ SECTION ////////////////////////////////////////-->

    <!--//////////////////////////////////////// NEWSLETTER SECTION ////////////////////////////////////////-->

    <section id="newsletter">

        <div class="container">
            <div class="row">

                <div class="col-md-6">
                    <p class="lead">Stay in the loop with our newsletter!</p>
                </div>
                
                <div class="col-md-6">

                    <!--////////// Newsletter Form //////////-->
                    <form runat="server" id="newsletter_signup">
                        <div class="input-group">
                     <%--     <input type="text" name="e-mail" id="e-mail" class="form-control input-hg">--%>
                          <asp:textbox runat="server" ID="subsc_email" class="form-control input-hg"/>
                          <span class="input-group-btn">
                            <asp:button runat="server" OnClick="subsc_button_Click" Text="Sign Up" class="btn btn-inverse btn-hg" ID="subsc_button"/>
                          </span>
                        </div><!-- /input-group -->
                    </form>
                    <!--////////// end of Newsletter Form ///////////-->

                     <div id="error-info"></div><!-- Error notification for newsletter signup form -->

                </div>

            </div><!-- /row -->
        </div><!-- /container -->

    </section>
    
    <!--//////////////////////////////////////// end NEWSLETTER SECTION ////////////////////////////////////////-->

    <!--//////////////////////////////////////// FOOTER SECTION ////////////////////////////////////////-->
    <section id="footer">
        <div class="bottom-menu-inverse">

            <div class="container">

                <div class="row">
                    <div class="col-md-6">
                        <p>Copyright &copy; 2013 PITCHDEA! Designed by <a href="#team" target="_blank">pitchdea-team</a>.</p>
                    </div>

                    <div class="col-md-6 social">
                        <ul class="bottom-icons">
                            <li>
                              <a href="#" class="fui-facebook"></a>
                            </li>
                             <li>
                              <a href="#" class="fui-twitter"></a>
                            </li>                             
                             <li>
                              <a href="#" class="fui-googleplus"></a>
                            </li>
                             <li>
                              <a href="#" class="fui-linkedin"></a>
                            </li>
                             
                          </ul>                      
                    </div>
                </div>
            
            </div><!-- /row -->
        </div><!-- /container -->

    </section>

    <!--//////////////////////////////////////// end FOOTER SECTION ////////////////////////////////////////-->



    <!--//////////////////////////////////////// JAVASCRIPT LOAD ////////////////////////////////////////-->

    <!-- Feel free to remove the scripts you are not going to use -->
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-46030859-1', 'pitchdea.com');
        ga('send', 'pageview');

	</script>
    <script src="js/jquery-1.8.3.min.js"></script>
    <script src="js/jquery-ui-1.10.3.custom.min.js"></script>
    <script src="js/jquery.ui.touch-punch.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.isotope.min.js"></script>
    <script src="js/jquery.magnific-popup.js"></script>
    <script src="js/jquery.fitvids.min.js"></script>
    <script src="assets/twitter/jquery.tweet.js"></script>
    <script src="js/bootstrap-select.js"></script>
    <script src="js/bootstrap-switch.js"></script>
    <script src="js/flatui-checkbox.js"></script>
    <script src="js/flatui-radio.js"></script>
    <script src="js/jquery.tagsinput.js"></script>
    <script src="js/jquery.placeholder.js"></script>
    <script src="js/custom.js"></script>

    <!--//////////////////////////////////////// end JAVASCRIPT LOAD ////////////////////////////////////////-->

  </body>
</html>
